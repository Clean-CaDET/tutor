using FluentResults;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using System.Text;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public class AgentOrchestrator : IAgentOrchestrator
{
    private const int MaxNonSubstantiveClosingTurns = 3;

    private readonly IAgentFactory _factory;
    private readonly ITurnUsageTracker _usageTracker;
    private readonly ILogger<AgentOrchestrator> _logger;

    public AgentOrchestrator(IAgentFactory factory, ITurnUsageTracker usageTracker, ILogger<AgentOrchestrator> logger)
    {
        _factory = factory;
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
            StreamFailure? streamFailure = null;
            await foreach (var chunk in streamRoute.Agent.StreamAsync(attempt.Turns, record, streamRoute.Ctx, ct))
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
        yield return CreateFinalChunk(directive: probeDirective);
        yield break;

        FinalChunk CreateFinalChunk(string? summary = null, ProbeDirective? directive = null)
            => new(attempt.Id, attempt.Status, intent, summary, directive, _usageTracker.Total);
    }

    private async IAsyncEnumerable<OrchestratorChunk> HandleClosingTurnAsync(ConceptRecord record,
        ConversationAttempt attempt, string newMessage, TurnIntent intent, [EnumeratorCancellation] CancellationToken ct)
    {
        FinalChunk CreateFinalChunk(string? summary = null, ProbeDirective? directive = null)
            => new(attempt.Id, attempt.Status, intent, summary, directive, _usageTracker.Total);

        if (intent == TurnIntent.Substantive)
        {
            var scoreResult = await ScoreClosingAsync(record, attempt.Turns, newMessage, ct);
            if (scoreResult.IsFailed)
            {
                yield return new ErrorChunk("Closing scoring failed.", 500);
                yield break;
            }
            attempt.Complete(newMessage, intent, scoreResult.Value);
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

    private RouteResult Route(ConceptRecord record, ConversationAttempt attempt,
        TurnIntent intent, TurnEvaluation? evaluation)
    {
        if (record.IsAttemptComplete(attempt) || attempt.IsHardCapReached())
            return new RouteResult.Transition();

        switch (intent)
        {
            case TurnIntent.Substantive:
            {
                if (evaluation is { HasMultipleConcerns: true })
                    return new RouteResult.Stream(_factory.CreateCritique(),
                        new AgentTurnContext(Evaluation: evaluation),
                        ProbeDirective: null);
                var next = record.PickNextTarget(attempt, attempt.GetStalledTargets());
                if (next == null) return new RouteResult.Transition();
                var ladderLevel = attempt.GetProbeLevelFor(next);
                var agent = attempt.IsScaffolding(ladderLevel) ? _factory.CreateScaffolding() : _factory.CreateProbe();
                return new RouteResult.Stream(agent, new AgentTurnContext(Target: next, Level: ladderLevel), new ProbeDirective(next, ladderLevel));
            }

            case TurnIntent.Stuck:
            {
                var stalledTargets = attempt.GetStalledTargets();
                var stuckTarget = attempt.GetLastProbe()?.Target;
                if (stuckTarget == null || stalledTargets.Contains(stuckTarget))
                {
                    stuckTarget = record.PickNextTarget(attempt, stalledTargets);
                    if (stuckTarget == null) return new RouteResult.Transition();
                    var first = attempt.FirstScaffoldLadderLevel;
                    return new RouteResult.Stream(
                        _factory.CreateScaffolding(),
                        new AgentTurnContext(Target: stuckTarget, Level: first),
                        new ProbeDirective(stuckTarget, first));
                }
                var ladderLevel = attempt.GetProbeLevelFor(stuckTarget);
                return new RouteResult.Stream(
                    _factory.CreateScaffolding(),
                    new AgentTurnContext(Target: stuckTarget, Level: ladderLevel),
                    new ProbeDirective(stuckTarget, ladderLevel));
            }

            case TurnIntent.Clarification:
            {
                var last = attempt.GetLastProbe();
                return new RouteResult.Stream(
                    _factory.CreateClarification(),
                    new AgentTurnContext(Target: last?.Target),
                    ProbeDirective: null);
            }

            case TurnIntent.SummaryRequest:
                return new RouteResult.Stream(
                    _factory.CreateSummary(),
                    new AgentTurnContext(),
                    ProbeDirective: null);

            case TurnIntent.OffTopic:
            default:
                return new RouteResult.OffTopic();
        }
    }

    private static bool ShouldAppendSoftCapNudge(TurnIntent intent) =>
        intent is TurnIntent.Substantive or TurnIntent.Stuck or TurnIntent.SummaryRequest;

    private Task<Result<TurnIntent>> ClassifyIntentAsync(ConceptRecord record, IReadOnlyList<ConversationTurn> history,
        string newMessage, CancellationToken ct)
    {
        var ctx = new AgentTurnContext(CurrentLearnerMessage: newMessage);
        return _factory.CreateIntentClassifier().CompleteAsync<IntentResponse, TurnIntent>(
            history, record, ctx,
            r => Enum.TryParse<TurnIntent>(r.Intent, ignoreCase: true, out var intent)
                ? Result.Ok(intent)
                : Result.Fail<TurnIntent>("Unrecognized intent."),
            "Intent classification failed.", ct);
    }

    private Task<Result<TurnEvaluation>> ScoreTurnAsync(ConceptRecord record,
        IReadOnlyList<ConversationTurn> history,
        string newMessage, CancellationToken ct)
    {
        var ctx = new AgentTurnContext(CurrentLearnerMessage: newMessage);
        return _factory.CreateTurnScorer().CompleteAsync<ScorerResponse, TurnEvaluation>(
            history, record, ctx,
            r => MapToEvaluation(r, record),
            "Scoring failed.", ct);
    }

    private Task<Result<TurnEvaluation>> ScoreClosingAsync(ConceptRecord record,
        IReadOnlyList<ConversationTurn> history,
        string newMessage, CancellationToken ct)
    {
        var ctx = new AgentTurnContext(CurrentLearnerMessage: newMessage);
        return _factory.CreateClosingScorer().CompleteAsync<ScorerResponse, TurnEvaluation>(
            history, record, ctx,
            r => MapToEvaluation(r, record),
            "Closing scoring failed.", ct);
    }

    private static Result<TurnEvaluation> MapToEvaluation(ScorerResponse parsed, ConceptRecord record)
    {
        if (parsed.CorrectnessScore is < 0 or > 5) return Result.Fail("Correctness out of range.");
        if (parsed.CompletenessScore is < 0 or > 5) return Result.Fail("Completeness out of range.");
        if (parsed.IntegrationScore is not null and (< 0 or > 5)) return Result.Fail("Integration out of range.");

        var validKpKeys = record.KeyPropositions.Select(kp => kp.Key).ToHashSet();
        var validKrKeys = record.KeyRelations.Select(kr => kr.Key).ToHashSet();
        var validCmKeys = record.CommonMisconceptions.Select(cm => cm.Key).ToHashSet();

        if (parsed.PropositionsCoveredKeys?.Any(k => !validKpKeys.Contains(k)) == true)
            return Result.Fail("Unknown proposition key.");
        if (parsed.RelationsArticulatedKeys?.Any(k => !validKrKeys.Contains(k)) == true)
            return Result.Fail("Unknown relation key.");
        if (parsed.MisconceptionsTriggeredKeys?.Any(k => !validCmKeys.Contains(k)) == true)
            return Result.Fail("Unknown misconception key.");

        return new TurnEvaluation(
            parsed.CorrectnessScore, parsed.CompletenessScore, parsed.IntegrationScore,
            parsed.Justification ?? string.Empty, parsed.NovelMisconceptions, parsed.PropositionsCoveredKeys ?? new List<string>(),
            parsed.MisconceptionsTriggeredKeys ?? new List<string>(), parsed.RelationsArticulatedKeys ?? new List<string>(),
            parsed.HasMultipleConcerns ?? false);
    }

    private abstract record RouteResult
    {
        public sealed record Stream(
            IAgentStream Agent, AgentTurnContext Ctx, ProbeDirective? ProbeDirective) : RouteResult;
        public sealed record OffTopic : RouteResult;
        public sealed record Transition : RouteResult;
    }
}
