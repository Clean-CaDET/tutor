using System.Runtime.CompilerServices;
using System.Text;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public class AgentOrchestrator : LlmCaller, IAgentOrchestrator
{
    private readonly ITurnUsageTracker _usageTracker;
    private readonly ILogger<AgentOrchestrator> _logger;

    public AgentOrchestrator(IAiChatService chatService, ITurnUsageTracker usageTracker,
        ILogger<AgentOrchestrator> logger) : base(chatService, usageTracker, logger)
    {
        _usageTracker = usageTracker;
        _logger = logger;
    }

    public async IAsyncEnumerable<OrchestratorChunk> ProcessSubmissionAsync(
        ConceptRecord record, ConversationAttempt attempt, string elaboration,
        [EnumeratorCancellation] CancellationToken ct)
    {
        using var scope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AttemptId"] = attempt.Id,
            ["RoundCount"] = attempt.Rounds.Count
        });

        var scoreResult = await ScoreElaborationAsync(record, elaboration, ct);
        if (scoreResult.IsFailed)
        {
            yield return new ErrorChunk("Scoring failed.", 500);
            yield break;
        }
        var evaluation = scoreResult.Value;

        attempt.BeginRound(elaboration, evaluation);

        if (attempt.IsGoodEnough())
        {
            attempt.Complete();
            yield return CreateFinalChunk(attempt);
            yield break;
        }

        if (attempt.IsHardCapReached())
        {
            attempt.Expire();
            yield return CreateFinalChunk(attempt);
            yield break;
        }

        var probes = attempt.SelectProbes();
        var fullResponse = new StringBuilder();
        await foreach (var chunk in StreamAgentAsync(
            LlmRequestFactory.ForEvaluationFeedback(record, elaboration, probes), "EvaluationFeedback", fullResponse, ct))
        {
            yield return chunk;
            if (chunk is ErrorChunk) yield break;
        }

        if (attempt.IsStagnating())
        {
            yield return new TokenChunk(SystemTurnCodes.StagnationRedirect);
        }
        else
        {
            yield return new TokenChunk(SystemTurnCodes.Push);
        }

        attempt.CompleteRound(fullResponse.ToString(), probes);
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

    private async Task<Result<RoundEvaluation>> ScoreElaborationAsync(ConceptRecord record, string elaboration, CancellationToken ct)
    {
        var result = await CompleteJsonAsync<ScoreResponseDto>(
            LlmRequestFactory.ForElaborationScoring(record, elaboration), "ElaborationScoring", ct);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.ToEvaluation(record);
    }

    private FinalChunk CreateFinalChunk(ConversationAttempt attempt)
        => new(attempt.Id, attempt.Status, attempt.FinalGrade, _usageTracker.Total);
}
