using FluentResults;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Text;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public class AgentOrchestrator : LlmCaller, IAgentOrchestrator
{
    private const int MaxNonSubstantiveClosingTurns = 3;

    private readonly ITurnUsageTracker _usageTracker;
    private readonly ILogger<AgentOrchestrator> _logger;

    public AgentOrchestrator(IAiChatService chatService, ITurnUsageTracker usageTracker,
        ILogger<AgentOrchestrator> logger) : base(chatService, usageTracker, logger)
    {
        _usageTracker = usageTracker;
        _logger = logger;
    }

    public async IAsyncEnumerable<OrchestratorChunk> ProcessTurnAsync(ConceptRecord record, ConversationAttempt attempt,
        string newMessage, [EnumeratorCancellation] CancellationToken ct)
    {
        using var turnScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AttemptId"] = attempt.Id,
            ["TurnOrd"] = attempt.Turns.Count
        });

        var intentResult = await ClassifyIntentAsync(record, attempt.Turns, newMessage, ct);
        if (intentResult.IsFailed)
        {
            yield return new ErrorChunk("Intent classification failed.", 500);
            yield break;
        }
        var intent = intentResult.Value;

        if (attempt.Status == AttemptStatus.InProgress)
        {
            await foreach (var chunk in HandleProgressTurnAsync(record, attempt, newMessage, intent, ct))
                yield return chunk;
        }
        else if(attempt.Status == AttemptStatus.InClosing)
        {
            await foreach (var chunk in HandleClosingTurnAsync(record, attempt, newMessage, intent, ct))
                yield return chunk;
        }
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleProgressTurnAsync(ConceptRecord record,
        ConversationAttempt attempt, string newMessage, TurnIntent intent, [EnumeratorCancellation] CancellationToken ct)
    {
        TurnEvaluation? evaluation = null;
        if (intent == TurnIntent.Substantive)
        {
            var scoreResult = await ScoreTurnAsync(record, attempt.Turns, newMessage, ct);
            if (scoreResult.IsFailed)
            {
                yield return new ErrorChunk("Scoring failed.", 500);
                yield break;
            }
            evaluation = scoreResult.Value;
        }

        attempt.AddLearnerTurn(newMessage, intent, evaluation);

        if (record.IsAttemptComplete(attempt) || attempt.IsHardCapReached())
        {
            attempt.TransitionToClosing(SystemTurnCodes.InClosingTransition);
            yield return new TokenChunk(SystemTurnCodes.InClosingTransition);
            yield return CreateFinalChunk(attempt);
            yield break;
        }

        var handler = intent switch
        {
            TurnIntent.Substantive    => HandleSubstantiveAsync(record, attempt, evaluation!, ct),
            TurnIntent.Stuck          => HandleStuckAsync(record, attempt, ct),
            TurnIntent.Clarification  => HandleClarificationAsync(record, attempt, ct),
            TurnIntent.SummaryRequest => HandleSummaryRequestAsync(record, attempt, ct),
            _                         => HandleOffTopicAsync(attempt)
        };
        await foreach (var chunk in handler.WithCancellation(ct))
            yield return chunk;
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleSubstantiveAsync(ConceptRecord record,
        ConversationAttempt attempt, TurnEvaluation evaluation, [EnumeratorCancellation] CancellationToken ct)
    {
        CompletionRequest request;
        string label;
        ActiveProbe? probe = null;

        if (evaluation.HasMultipleConcerns && !evaluation.HasBroadCoverage(record.CountTargets()))
        {
            request = LlmRequestFactory.ForCritique(record, attempt.Turns, evaluation);
            label = "Critique";
        }
        else
        {
            var next = record.PickNextTarget(attempt);
            if (next == null)
            {
                attempt.TransitionToClosing(SystemTurnCodes.InClosingTransition);
                yield return new TokenChunk(SystemTurnCodes.InClosingTransition);
                yield return CreateFinalChunk(attempt);
                yield break;
            }
            var level = attempt.GetProbeLevelFor(next);
            probe = new ActiveProbe(next, level);
            var isScaffolding = attempt.IsScaffolding(level);
            request = isScaffolding
                ? LlmRequestFactory.ForScaffolding(record, attempt.Turns, probe)
                : LlmRequestFactory.ForProbing(record, attempt.Turns, probe);
            label = isScaffolding ? "Scaffolding" : "Probing";
        }

        var fullResponse = new StringBuilder();
        await foreach (var chunk in StreamAgentAsync(request, label, fullResponse, ct))
        {
            yield return chunk;
            if (chunk is ErrorChunk) yield break;
        }

        if (attempt.IsSoftCapReached())
        {
            fullResponse.Append(SystemTurnCodes.SoftCapNudge);
            yield return new TokenChunk(SystemTurnCodes.SoftCapNudge);
        }

        attempt.AddSystemTurn(fullResponse.ToString(), probe);
        yield return CreateFinalChunk(attempt);
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleStuckAsync(ConceptRecord record,
        ConversationAttempt attempt, [EnumeratorCancellation] CancellationToken ct)
    {
        var probe = GetNextProbe(record, attempt);

        if (probe == null)
        {
            attempt.TransitionToClosing(SystemTurnCodes.InClosingTransition);
            yield return new TokenChunk(SystemTurnCodes.InClosingTransition);
            yield return CreateFinalChunk(attempt);
            yield break;
        }

        var fullResponse = new StringBuilder();
        await foreach (var chunk in StreamAgentAsync(LlmRequestFactory.ForScaffolding(record, attempt.Turns, probe), "Scaffolding", fullResponse, ct))
        {
            yield return chunk;
            if (chunk is ErrorChunk) yield break;
        }

        if (attempt.IsSoftCapReached())
        {
            fullResponse.Append(SystemTurnCodes.SoftCapNudge);
            yield return new TokenChunk(SystemTurnCodes.SoftCapNudge);
        }

        attempt.AddSystemTurn(fullResponse.ToString(), probe);
        yield return CreateFinalChunk(attempt);
    }

    private static ActiveProbe? GetNextProbe(ConceptRecord record, ConversationAttempt attempt)
    {
        var nextProbe = attempt.GetNextProbe();
        if (nextProbe != null) return nextProbe;
        var nextTarget = record.PickNextTarget(attempt);
        return nextTarget == null ? null : new ActiveProbe(nextTarget, attempt.FirstScaffoldLadderLevel);
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleClarificationAsync(ConceptRecord record,
        ConversationAttempt attempt, [EnumeratorCancellation] CancellationToken ct)
    {
        var fullResponse = new StringBuilder();
        await foreach (var chunk in StreamAgentAsync(LlmRequestFactory.ForClarification(record, attempt.Turns, attempt.GetLastProbe()), "Clarification", fullResponse, ct))
        {
            yield return chunk;
            if (chunk is ErrorChunk) yield break;
        }

        if (attempt.IsSoftCapReached())
        {
            fullResponse.Append(SystemTurnCodes.SoftCapNudge);
            yield return new TokenChunk(SystemTurnCodes.SoftCapNudge);
        }

        attempt.AddSystemTurn(fullResponse.ToString());
        yield return CreateFinalChunk(attempt);
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleSummaryRequestAsync(ConceptRecord record,
        ConversationAttempt attempt, [EnumeratorCancellation] CancellationToken ct)
    {
        var fullResponse = new StringBuilder();
        await foreach (var chunk in StreamAgentAsync(LlmRequestFactory.ForSummary(record, attempt.Turns), "Summary", fullResponse, ct))
        {
            yield return chunk;
            if (chunk is ErrorChunk) yield break;
        }

        if (attempt.IsSoftCapReached())
        {
            fullResponse.Append(SystemTurnCodes.SoftCapNudge);
            yield return new TokenChunk(SystemTurnCodes.SoftCapNudge);
        }

        attempt.AddSystemTurn(fullResponse.ToString());
        yield return CreateFinalChunk(attempt);
    }

    #pragma warning disable CS1998
    private async IAsyncEnumerable<OrchestratorChunk> HandleOffTopicAsync(ConversationAttempt attempt)
    #pragma warning restore CS1998
    {
        var fullResponse = new StringBuilder(SystemTurnCodes.OffTopic);
        yield return new TokenChunk(SystemTurnCodes.OffTopic);

        if (attempt.IsSoftCapReached())
        {
            fullResponse.Append(SystemTurnCodes.SoftCapNudge);
            yield return new TokenChunk(SystemTurnCodes.SoftCapNudge);
        }

        attempt.AddSystemTurn(fullResponse.ToString());
        yield return CreateFinalChunk(attempt);
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleClosingTurnAsync(ConceptRecord record,
        ConversationAttempt attempt, string newMessage, TurnIntent intent, [EnumeratorCancellation] CancellationToken ct)
    {
        if (intent == TurnIntent.Substantive)
        {
            var scoreResult = await ScoreClosingAsync(record, newMessage, ct);
            if (scoreResult.IsFailed)
            {
                yield return new ErrorChunk("Closing scoring failed.", 500);
                yield break;
            }
            attempt.AddLearnerTurn(newMessage, intent, scoreResult.Value);
            var grade = scoreResult.Value.ComputeGrade(record.CountTargets());
            attempt.Complete(grade);
            yield return new TokenChunk(attempt.Summary!);
            yield return CreateFinalChunk(attempt, attempt.Summary);
            yield break;
        }

        attempt.AddLearnerTurn(newMessage, intent);

        if (attempt.CountNonSubstantiveClosingTurns() >= MaxNonSubstantiveClosingTurns)
        {
            attempt.Expire(SystemTurnCodes.ExpiredNotice);
            yield return new TokenChunk(SystemTurnCodes.ExpiredNotice);
            yield return CreateFinalChunk(attempt);
            yield break;
        }

        attempt.AddSystemTurn(SystemTurnCodes.NonSubstantiveInClosingNudge);
        yield return new TokenChunk(SystemTurnCodes.NonSubstantiveInClosingNudge);
        yield return CreateFinalChunk(attempt);
    }

    private async IAsyncEnumerable<OrchestratorChunk> StreamAgentAsync(CompletionRequest request,
        string label, StringBuilder output, [EnumeratorCancellation] CancellationToken ct)
    {
        StreamFailure? failure = null;
        await foreach (var chunk in StreamAsync(request, label, ct))
        {
            if (chunk is StreamFailure f) { failure = f; break; }
            var content = ((StreamToken)chunk).Content;
            output.Append(content);
            yield return new TokenChunk(content);
        }
        if (failure != null)
            yield return new ErrorChunk(failure.Reason, 500);
    }

    private FinalChunk CreateFinalChunk(ConversationAttempt attempt, string? summary = null)
        => new(attempt.Id, attempt.Status, summary, _usageTracker.Total);

    private async Task<Result<TurnIntent>> ClassifyIntentAsync(ConceptRecord record,
        IReadOnlyList<ConversationTurn> history, string newMessage, CancellationToken ct)
    {
        var result = await CompleteJsonAsync<IntentResponse>(
            LlmRequestFactory.ForIntentClassification(record, history, newMessage), "IntentClassification", ct);
        if (result.IsFailed) return Result.Fail<TurnIntent>(result.Errors);
        return Enum.TryParse<TurnIntent>(result.Value.Intent, ignoreCase: true, out var intent)
            ? intent
            : Result.Fail("Unrecognized intent.");
    }

    private async Task<Result<TurnEvaluation>> ScoreTurnAsync(ConceptRecord record,
        IReadOnlyList<ConversationTurn> history, string newMessage, CancellationToken ct)
    {
        var result = await CompleteJsonAsync<ScoreResponse>(
            LlmRequestFactory.ForTurnScoring(record, history, newMessage), "TurnScoring", ct);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.ToEvaluation(record);
    }

    private async Task<Result<TurnEvaluation>> ScoreClosingAsync(ConceptRecord record,
        string newMessage, CancellationToken ct)
    {
        var result = await CompleteJsonAsync<ScoreResponse>(
            LlmRequestFactory.ForClosingScoring(record, newMessage), "ClosingScoring", ct);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.ToEvaluation(record);
    }
}
