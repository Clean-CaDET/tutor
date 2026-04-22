using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public class AgentOrchestratorService : IAgentOrchestratorService
{
    private const int ScaffoldingLevel = 4;

    private readonly IIntentClassifier _classifier;
    private readonly IScorer _scorer;
    private readonly IProbeAgent _probeAgent;
    private readonly ICritiqueAgent _critiqueAgent;
    private readonly IClarificationAgent _clarificationAgent;
    private readonly IRedirectAgent _redirectAgent;
    private readonly IMetaHelpAgent _metaHelpAgent;
    private readonly IScaffoldingAgent _scaffoldingAgent;
    private readonly IClosingAgent _closingAgent;
    private readonly ISummaryAgent _summaryAgent;
    private readonly ILogger<AgentOrchestratorService> _logger;

    public AgentOrchestratorService(
        IIntentClassifier classifier, IScorer scorer,
        IProbeAgent probeAgent, ICritiqueAgent critiqueAgent,
        IClarificationAgent clarificationAgent, IRedirectAgent redirectAgent,
        IMetaHelpAgent metaHelpAgent, IScaffoldingAgent scaffoldingAgent,
        IClosingAgent closingAgent, ISummaryAgent summaryAgent,
        ILogger<AgentOrchestratorService> logger)
    {
        _classifier = classifier;
        _scorer = scorer;
        _probeAgent = probeAgent;
        _critiqueAgent = critiqueAgent;
        _clarificationAgent = clarificationAgent;
        _redirectAgent = redirectAgent;
        _metaHelpAgent = metaHelpAgent;
        _scaffoldingAgent = scaffoldingAgent;
        _closingAgent = closingAgent;
        _summaryAgent = summaryAgent;
        _logger = logger;
    }

    public async IAsyncEnumerable<OrchestratorChunk> ProcessTurnAsync(
        ConversationAttempt attempt, ConceptElaborationTask task,
        string learnerContent, [EnumeratorCancellation] CancellationToken ct)
    {
        using var turnScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AttemptId"] = attempt.Id,
            ["TurnOrd"] = attempt.Turns.Count
        });

        var history = attempt.Turns.ToList();

        var intentResult = await _classifier.ClassifyAsync(learnerContent, history, task, ct);
        if (intentResult.IsFailed)
        {
            yield return new ErrorChunk("Intent classification failed.", 500);
            yield break;
        }

        var intent = intentResult.Value;
        TurnEvaluation? evaluation = null;
        if (intent == TurnIntent.Substantive)
        {
            var scoreResult = await _scorer.ScoreAsync(learnerContent, history, task, ct);
            if (scoreResult.IsFailed)
            {
                yield return new ErrorChunk("Scoring failed.", 500);
                yield break;
            }
            evaluation = scoreResult.Value;
        }

        attempt.AddLearnerTurn(learnerContent, intent, evaluation);

        var route = DecideRoute(attempt, task, intent, evaluation);

        var fullResponse = new StringBuilder();
        StreamFailure? streamFailure = null;
        await foreach (var chunk in Stream(route, attempt, task, ct))
        {
            if (chunk is StreamFailure failure)
            {
                streamFailure = failure;
                break;
            }
            var content = ((StreamToken)chunk).Content;
            fullResponse.Append(content);
            yield return new TokenChunk(content);
        }

        if (streamFailure != null)
        {
            yield return new ErrorChunk(streamFailure.Reason, 500);
            yield break;
        }

        attempt.AddSystemTurn(fullResponse.ToString(), route.ProbeDirective);

        string? summary = null;
        if (route.Closing == ClosingReason.AllCovered)
        {
            var summaryResult = await _summaryAgent.SummarizeAsync(attempt, task, ct);
            summary = summaryResult.IsSuccess ? summaryResult.Value : null;
            attempt.Complete(summary);
        }
        else if (route.Closing == ClosingReason.HardCapReached)
        {
            var summaryResult = await _summaryAgent.SummarizeAsync(attempt, task, ct);
            summary = summaryResult.IsSuccess ? summaryResult.Value : null;
            attempt.Expire(summary);
        }

        yield return new FinalChunk(
            attempt.Id, attempt.Status, intent, summary, route.ProbeDirective);
    }

    private IAsyncEnumerable<StreamOutput> Stream(
        RouteDecision route, ConversationAttempt attempt,
        ConceptElaborationTask task, CancellationToken ct)
    {
        return route.Kind switch
        {
            RouteKind.Probe => _probeAgent.StreamAsync(route.ProbeDirective!, attempt, task, ct),
            RouteKind.Scaffold => _scaffoldingAgent.StreamAsync(route.ProbeDirective!, attempt, task, ct),
            RouteKind.Critique => _critiqueAgent.StreamAsync(route.Evaluation!, attempt, task, ct),
            RouteKind.Clarification => _clarificationAgent.StreamAsync(attempt, task, route.LastProbe, ct),
            RouteKind.Redirect => _redirectAgent.StreamAsync(task, ct),
            RouteKind.MetaHelp => _metaHelpAgent.StreamAsync(task, route.ProgressLine!, route.NextTarget, ct),
            RouteKind.Closing => _closingAgent.StreamAsync(task, route.Closing!.Value, ct),
            _ => throw new InvalidOperationException($"Unknown route kind: {route.Kind}")
        };
    }

    private RouteDecision DecideRoute(
        ConversationAttempt attempt, ConceptElaborationTask task,
        TurnIntent intent, TurnEvaluation? evaluation)
    {
        if (task.IsAttemptComplete(attempt))
            return RouteDecision.Close(ClosingReason.AllCovered);

        if (attempt.IsHardCapReached())
            return RouteDecision.Close(ClosingReason.HardCapReached);

        switch (intent)
        {
            case TurnIntent.Clarification:
                return RouteDecision.Clarify(FindLastProbe(attempt));

            case TurnIntent.OffTopic:
                return RouteDecision.Redirect();

            case TurnIntent.MetaHelp:
            {
                var progressLine = RenderProgressLine(attempt, task);
                var next = PickNextTarget(attempt, task);
                return RouteDecision.Meta(progressLine, next);
            }

            case TurnIntent.Stuck:
            {
                var next = PickNextTarget(attempt, task);
                if (next == null) return RouteDecision.Close(ClosingReason.AllCovered);
                var level = DeriveLevel(attempt, next);
                var directive = new ProbeDirective(next.Value.Type, next.Value.Id, Math.Max(level, ScaffoldingLevel));
                return RouteDecision.Scaffold(directive);
            }

            case TurnIntent.Substantive:
            {
                if (evaluation is { HasMultipleConcerns: true })
                    return RouteDecision.CritiqueFor(evaluation);

                var next = PickNextTarget(attempt, task);
                if (next == null) return RouteDecision.Close(ClosingReason.AllCovered);
                var level = DeriveLevel(attempt, next);
                var directive = new ProbeDirective(next.Value.Type, next.Value.Id, level);

                return level >= ScaffoldingLevel
                    ? RouteDecision.Scaffold(directive)
                    : RouteDecision.Probe(directive);
            }

            default:
                return RouteDecision.Redirect();
        }
    }

    private static (ProbeTargetType Type, int Id)? PickNextTarget(
        ConversationAttempt attempt, ConceptElaborationTask task)
    {
        var uncoveredKp = task.GetUncoveredPropositionIds(attempt);
        if (uncoveredKp.Count > 0)
            return (ProbeTargetType.KeyProposition, uncoveredKp.Min());

        var unarticulatedKr = task.GetUnarticulatedRelationIds(attempt);
        return unarticulatedKr.Count > 0
            ? (ProbeTargetType.KeyRelation, unarticulatedKr.Min())
            : null;
    }

    private static int DeriveLevel(
        ConversationAttempt attempt, (ProbeTargetType Type, int Id)? target)
    {
        if (target == null) return 1;
        var priorProbes = attempt.Turns.Count(t =>
            t.Role == TurnRole.System &&
            t.ProbeTargetType == target.Value.Type &&
            t.ProbeTargetId == target.Value.Id);
        return priorProbes + 1;
    }

    private static ProbeDirective? FindLastProbe(ConversationAttempt attempt)
    {
        var last = attempt.Turns
            .Where(t => t.Role == TurnRole.System && t.ProbeTargetType.HasValue)
            .OrderByDescending(t => t.Order)
            .FirstOrDefault();
        if (last == null) return null;
        return new ProbeDirective(last.ProbeTargetType!.Value, last.ProbeTargetId!.Value, last.ProbeLevel!.Value);
    }

    private static string RenderProgressLine(ConversationAttempt attempt, ConceptElaborationTask task)
    {
        var coveredKp = attempt.GetCoveredPropositionIds().Count;
        var totalKp = task.KeyPropositions.Count;
        var articulatedKr = attempt.GetArticulatedRelationIds().Count;
        var totalKr = task.KeyRelations.Count;

        return totalKr > 0
            ? $"Dosadašnji napredak: pokriveno {coveredKp}/{totalKp} ključnih izjava i {articulatedKr}/{totalKr} ključnih veza."
            : $"Dosadašnji napredak: pokriveno {coveredKp}/{totalKp} ključnih izjava.";
    }

    private enum RouteKind { Probe, Scaffold, Critique, Clarification, Redirect, MetaHelp, Closing }

    private sealed record RouteDecision(
        RouteKind Kind,
        ProbeDirective? ProbeDirective = null,
        TurnEvaluation? Evaluation = null,
        ProbeDirective? LastProbe = null,
        string? ProgressLine = null,
        ProbeDirective? NextTarget = null,
        ClosingReason? Closing = null)
    {
        public static RouteDecision Probe(ProbeDirective d) => new(RouteKind.Probe, ProbeDirective: d);
        public static RouteDecision Scaffold(ProbeDirective d) => new(RouteKind.Scaffold, ProbeDirective: d);
        public static RouteDecision CritiqueFor(TurnEvaluation e) => new(RouteKind.Critique, Evaluation: e);
        public static RouteDecision Clarify(ProbeDirective? last) => new(RouteKind.Clarification, LastProbe: last);
        public static RouteDecision Redirect() => new(RouteKind.Redirect);
        public static RouteDecision Meta(string progressLine, (ProbeTargetType Type, int Id)? next)
        {
            var nextDirective = next == null ? null : new ProbeDirective(next.Value.Type, next.Value.Id, 1);
            return new RouteDecision(RouteKind.MetaHelp, ProgressLine: progressLine, NextTarget: nextDirective);
        }
        public static RouteDecision Close(ClosingReason reason) => new(RouteKind.Closing, Closing: reason);
    }
}
