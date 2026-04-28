using FluentResults;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Text;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

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

        if (attempt.Status == AttemptStatus.InClosing)
        {
            await foreach (var chunk in HandleClosingTurnAsync(record, attempt, newMessage, intent, ct))
                yield return chunk;
            yield break;
        }

        await foreach (var chunk in HandleProgressTurnAsync(record, attempt, newMessage, intent, ct))
            yield return chunk;
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleProgressTurnAsync(ConceptRecord record,
        ConversationAttempt attempt, string newMessage, TurnIntent intent, [EnumeratorCancellation] CancellationToken ct)
    {
        FinalChunk CreateFinalChunk(string? summary = null)
            => new(attempt.Id, attempt.Status, intent, summary, _usageTracker.Total);

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

        var route = Route(record, attempt, intent, evaluation);

        if (route is RouteResult.Transition)
        {
            attempt.TransitionToClosing(ElaborationTexts.InClosingTransition);
            yield return new TokenChunk(ElaborationTexts.InClosingTransition);
            yield return CreateFinalChunk();
            yield break;
        }

        var fullResponse = new StringBuilder();

        if (route is RouteResult.OffTopic)
        {
            fullResponse.Append(ElaborationTexts.OffTopic);
            yield return new TokenChunk(ElaborationTexts.OffTopic);
        }
        else if (route is RouteResult.Stream streamRoute)
        {
            var request = BuildRequest(streamRoute.Kind, attempt.Turns, record, streamRoute.Ctx);
            StreamFailure? streamFailure = null;
            await foreach (var chunk in StreamAsync(request, streamRoute.Kind.ToString(), ct))
            {
                if (chunk is StreamFailure failure) { streamFailure = failure; break; }
                var content = ((StreamToken)chunk).Content;
                fullResponse.Append(content);
                yield return new TokenChunk(content);
            }

            if (streamFailure != null)
            {
                yield return new ErrorChunk(streamFailure.Reason, 500);
                yield break;
            }
        }

        if (attempt.IsSoftCapReached() && ShouldAppendSoftCapNudge(intent))
        {
            var nudge = "\n\n" + ElaborationTexts.SoftCapNudge;
            fullResponse.Append(nudge);
            yield return new TokenChunk(nudge);
        }

        var probeDirective = (route as RouteResult.Stream)?.ProbeDirective;
        attempt.AddSystemTurn(fullResponse.ToString(), probeDirective);
        yield return CreateFinalChunk();
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleClosingTurnAsync(ConceptRecord record,
        ConversationAttempt attempt, string newMessage, TurnIntent intent, [EnumeratorCancellation] CancellationToken ct)
    {
        FinalChunk CreateFinalChunk(string? summary = null)
            => new(attempt.Id, attempt.Status, intent, summary, _usageTracker.Total);

        if (intent == TurnIntent.Substantive)
        {
            var scoreResult = await ScoreClosingAsync(record, attempt.Turns, newMessage, ct);
            if (scoreResult.IsFailed)
            {
                yield return new ErrorChunk("Closing scoring failed.", 500);
                yield break;
            }
            attempt.AddLearnerTurn(newMessage, intent, scoreResult.Value);
            attempt.Complete(scoreResult.Value);
            yield return new TokenChunk(attempt.Summary!);
            yield return CreateFinalChunk(attempt.Summary);
            yield break;
        }

        attempt.AddLearnerTurn(newMessage, intent, null);

        if (attempt.CountNonSubstantiveClosingTurns() >= MaxNonSubstantiveClosingTurns)
        {
            attempt.AddSystemTurn(ElaborationTexts.ExpiredNotice);
            attempt.Expire(summary: null);
            yield return new TokenChunk(ElaborationTexts.ExpiredNotice);
            yield return CreateFinalChunk();
            yield break;
        }

        attempt.AddSystemTurn(ElaborationTexts.NonSubstantiveInClosingNudge);
        yield return new TokenChunk(ElaborationTexts.NonSubstantiveInClosingNudge);
        yield return CreateFinalChunk();
    }

    private static RouteResult Route(ConceptRecord record, ConversationAttempt attempt,
        TurnIntent intent, TurnEvaluation? evaluation)
    {
        if (record.IsAttemptComplete(attempt) || attempt.IsHardCapReached())
            return new RouteResult.Transition();

        switch (intent)
        {
            case TurnIntent.Substantive:
            {
                if (evaluation != null && evaluation.HasMultipleConcerns)
                    return new RouteResult.Stream(AgentKind.Critique,
                        new AgentTurnContext(Evaluation: evaluation), null);
                var next = record.PickNextTarget(attempt);
                if (next == null) return new RouteResult.Transition();
                var ladderLevel = attempt.GetProbeLevelFor(next);
                var kind = attempt.IsScaffolding(ladderLevel) ? AgentKind.Scaffolding : AgentKind.Probe;
                return new RouteResult.Stream(kind, new AgentTurnContext(Target: next, Level: ladderLevel), new ProbeDirective(next, ladderLevel));
            }

            case TurnIntent.Stuck:
            {
                var stuckTarget = attempt.GetLastProbe()?.Target;
                if (stuckTarget == null || attempt.GetStalledTargets().Contains(stuckTarget))
                {
                    stuckTarget = record.PickNextTarget(attempt);
                    if (stuckTarget == null) return new RouteResult.Transition();
                    var first = attempt.FirstScaffoldLadderLevel;
                    return new RouteResult.Stream(
                        AgentKind.Scaffolding,
                        new AgentTurnContext(Target: stuckTarget, Level: first),
                        new ProbeDirective(stuckTarget, first));
                }
                var ladderLevel = attempt.GetProbeLevelFor(stuckTarget);
                return new RouteResult.Stream(
                    AgentKind.Scaffolding,
                    new AgentTurnContext(Target: stuckTarget, Level: ladderLevel),
                    new ProbeDirective(stuckTarget, ladderLevel));
            }

            case TurnIntent.Clarification:
            {
                var last = attempt.GetLastProbe();
                return new RouteResult.Stream(
                    AgentKind.Clarification,
                    new AgentTurnContext(Target: last?.Target),
                    null);
            }

            case TurnIntent.SummaryRequest:
                return new RouteResult.Stream(AgentKind.Summary, new AgentTurnContext(), null);

            case TurnIntent.OffTopic:
            default:
                return new RouteResult.OffTopic();
        }
    }

    private static bool ShouldAppendSoftCapNudge(TurnIntent intent) =>
        intent is TurnIntent.Substantive or TurnIntent.Stuck or TurnIntent.SummaryRequest;

    private static CompletionRequest BuildRequest(AgentKind kind,
        IReadOnlyList<ConversationTurn> history, ConceptRecord record, AgentTurnContext ctx)
    {
        var config = AgentConfigs.ByKind[kind];
        var messages = ConversationHistoryMapper.Map(history, config.HistoryWindow);
        messages.Add(ChatMessage.FromUser(RuntimeContextBlock.Render(ctx)));
        return CompletionRequest.Create(messages, config.BuildSystemPrompt(record),
            maxTokens: config.MaxTokens, temperature: config.Temperature);
    }

    private async Task<Result<TurnIntent>> ClassifyIntentAsync(ConceptRecord record,
        IReadOnlyList<ConversationTurn> history, string newMessage, CancellationToken ct)
    {
        var ctx = new AgentTurnContext(CurrentLearnerMessage: newMessage);
        var result = await CompleteJsonAsync<IntentResponse>(
            BuildRequest(AgentKind.IntentClassifier, history, record, ctx), nameof(AgentKind.IntentClassifier), ct);
        if (result.IsFailed) return Result.Fail<TurnIntent>(result.Errors);
        return Enum.TryParse<TurnIntent>(result.Value.Intent, ignoreCase: true, out var intent)
            ? intent
            : Result.Fail("Unrecognized intent.");
    }

    private async Task<Result<TurnEvaluation>> ScoreTurnAsync(ConceptRecord record,
        IReadOnlyList<ConversationTurn> history, string newMessage, CancellationToken ct)
    {
        var ctx = new AgentTurnContext(CurrentLearnerMessage: newMessage);
        var result = await CompleteJsonAsync<ScorerResponse>(
            BuildRequest(AgentKind.TurnScorer, history, record, ctx), nameof(AgentKind.TurnScorer), ct);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.ToEvaluation(record);
    }

    private async Task<Result<TurnEvaluation>> ScoreClosingAsync(ConceptRecord record,
        IReadOnlyList<ConversationTurn> history, string newMessage, CancellationToken ct)
    {
        var ctx = new AgentTurnContext(CurrentLearnerMessage: newMessage);
        var result = await CompleteJsonAsync<ScorerResponse>(
            BuildRequest(AgentKind.ClosingScorer, history, record, ctx), nameof(AgentKind.ClosingScorer), ct);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.ToEvaluation(record);
    }

    private abstract record RouteResult
    {
        public sealed record Stream(AgentKind Kind, AgentTurnContext Ctx, ProbeDirective? ProbeDirective) : RouteResult;
        public sealed record OffTopic : RouteResult;
        public sealed record Transition : RouteResult;
    }
}
