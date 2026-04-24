using System.Runtime.CompilerServices;
using System.Text;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public class AgentOrchestratorService : IAgentOrchestratorService
{
    private const int ScaffoldingLevel = 4;

    private readonly IAgentStream _stream;
    private readonly IAgentJson _json;
    private readonly ITurnUsageTracker _usageTracker;
    private readonly ILogger<AgentOrchestratorService> _logger;

    public AgentOrchestratorService(
        IAgentStream stream, IAgentJson json,
        ITurnUsageTracker usageTracker, ILogger<AgentOrchestratorService> logger)
    {
        _stream = stream;
        _json = json;
        _usageTracker = usageTracker;
        _logger = logger;
    }

    public async IAsyncEnumerable<OrchestratorChunk> ProcessTurnAsync(
        ConversationAttempt attempt, ConceptElaborationTask task, ConceptRecord record,
        string learnerContent, [EnumeratorCancellation] CancellationToken ct)
    {
        using var turnScope = _logger.BeginScope(new Dictionary<string, object>
        {
            ["AttemptId"] = attempt.Id,
            ["TurnOrd"] = attempt.Turns.Count
        });

        var historyBeforeTurn = (IReadOnlyList<ConversationTurn>)attempt.Turns.ToList();

        var intentResult = await ClassifyIntentAsync(historyBeforeTurn, record, task, learnerContent, ct);
        if (intentResult.IsFailed)
        {
            yield return new ErrorChunk("Intent classification failed.", 500);
            yield break;
        }

        var intent = intentResult.Value;
        TurnEvaluation? evaluation = null;
        if (intent == TurnIntent.Substantive)
        {
            var scoreResult = await ScoreTurnAsync(historyBeforeTurn, record, task, learnerContent, ct);
            if (scoreResult.IsFailed)
            {
                yield return new ErrorChunk("Scoring failed.", 500);
                yield break;
            }
            evaluation = scoreResult.Value;
        }

        attempt.AddLearnerTurn(learnerContent, intent, evaluation);

        var route = DecideRoute(attempt, record, intent, evaluation);
        var historyForStreaming = (IReadOnlyList<ConversationTurn>)attempt.Turns.ToList();

        var (streamKind, streamCtx) = BuildStreamContext(route, task, record, attempt.IsSoftCapReached());

        var fullResponse = new StringBuilder();
        StreamFailure? streamFailure = null;
        await foreach (var chunk in _stream.StreamAsync(streamKind, historyForStreaming, record, streamCtx, ct))
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
        if (route.Closing is ClosingReason.AllCovered or ClosingReason.HardCapReached)
        {
            summary = await SummarizeAsync(attempt.Turns, record, task, ct);
            if (route.Closing == ClosingReason.AllCovered) attempt.Complete(summary);
            else attempt.Expire(summary);
        }

        yield return new FinalChunk(
            attempt.Id, attempt.Status, intent, summary, route.ProbeDirective, _usageTracker.Total);
    }

    private Task<Result<TurnIntent>> ClassifyIntentAsync(
        IReadOnlyList<ConversationTurn> history, ConceptRecord record,
        ConceptElaborationTask task, string learnerContent, CancellationToken ct)
    {
        var ctx = new AgentTurnContext(
            Instruction: "Classify the current learner message. Return JSON only.",
            CurrentLearnerMessage: learnerContent,
            ConceptTitle: task.Title);

        return _json.CompleteAsync<IntentResponse, TurnIntent>(
            AgentKind.IntentClassifier, history, record, ctx,
            r => Enum.TryParse<TurnIntent>(r.Intent, ignoreCase: true, out var intent)
                ? Result.Ok(intent)
                : Result.Fail<TurnIntent>("Unrecognized intent."),
            "Intent classification failed.", ct);
    }

    private Task<Result<TurnEvaluation>> ScoreTurnAsync(
        IReadOnlyList<ConversationTurn> history, ConceptRecord record,
        ConceptElaborationTask task, string learnerContent, CancellationToken ct)
    {
        var ctx = new AgentTurnContext(
            Instruction: "Score the current learner message against the rubric. Return JSON only.",
            CurrentLearnerMessage: learnerContent,
            ConceptTitle: task.Title);

        return _json.CompleteAsync<ScorerResponse, TurnEvaluation>(
            AgentKind.Scorer, history, record, ctx,
            r => MapToEvaluation(r, record),
            "Scoring failed.", ct);
    }

    private async Task<string?> SummarizeAsync(
        IEnumerable<ConversationTurn> turns, ConceptRecord record,
        ConceptElaborationTask task, CancellationToken ct)
    {
        var history = (IReadOnlyList<ConversationTurn>)turns.ToList();
        var ctx = new AgentTurnContext(
            Instruction: "Summarize what the learner demonstrated understanding of in 2-4 sentences in Serbian. Paraphrase only, no verbatim quotes of rubric items.",
            ConceptTitle: task.Title);

        var buffer = new StringBuilder();
        await foreach (var chunk in _stream.StreamAsync(AgentKind.Summary, history, record, ctx, ct))
        {
            if (chunk is StreamFailure) return null;
            buffer.Append(((StreamToken)chunk).Content);
        }

        return buffer.Length > 0 ? buffer.ToString() : null;
    }

    private static Result<TurnEvaluation> MapToEvaluation(ScorerResponse parsed, ConceptRecord record)
    {
        if (parsed.CorrectnessScore is < 1 or > 3) return Result.Fail("Correctness out of range.");
        if (parsed.CompletenessScore is < 1 or > 3) return Result.Fail("Completeness out of range.");
        if (parsed.DiscriminationScore is not null and (< 1 or > 3)) return Result.Fail("Discrimination out of range.");
        if (parsed.IntegrationScore is not null and (< 1 or > 3)) return Result.Fail("Integration out of range.");

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
            parsed.CorrectnessScore, parsed.CompletenessScore,
            parsed.DiscriminationScore, parsed.IntegrationScore,
            parsed.Justification ?? string.Empty, parsed.NovelMisconceptions,
            parsed.PropositionsCoveredKeys ?? new List<string>(),
            parsed.MisconceptionsTriggeredKeys ?? new List<string>(),
            parsed.RelationsArticulatedKeys ?? new List<string>(),
            parsed.HasMultipleConcerns ?? false);
    }

    private static (AgentKind Kind, AgentTurnContext Ctx) BuildStreamContext(
        RouteDecision route, ConceptElaborationTask task, ConceptRecord record, bool softCap) =>
        route.Kind switch
        {
            RouteKind.Probe => (AgentKind.Probe, new AgentTurnContext(
                Instruction: "Produce one probe question for the target at the given level.",
                Target: ResolveTarget(record, route.ProbeDirective),
                SoftCapReached: softCap,
                ConceptTitle: task.Title)),

            RouteKind.Scaffold => (AgentKind.Scaffolding, new AgentTurnContext(
                Instruction: "Produce a scaffold (forced choice, code skeleton, or analogy) that helps the learner reach the target without revealing it.",
                Target: ResolveTarget(record, route.ProbeDirective),
                ConceptTitle: task.Title)),

            RouteKind.Critique => (AgentKind.Critique, new AgentTurnContext(
                Instruction: "Produce a short bulleted critique of the latest learner turn based on the evaluation. Do not ask a new Socratic question.",
                Evaluation: route.Evaluation,
                SoftCapReached: softCap,
                ConceptTitle: task.Title)),

            RouteKind.Clarification => (AgentKind.Clarification, new AgentTurnContext(
                Instruction: "Rephrase the tutor's prior question in simpler terms. Do not answer it. Then invite the learner to resume.",
                Target: ResolveTarget(record, route.LastProbe),
                ConceptTitle: task.Title)),

            RouteKind.Redirect => (AgentKind.Redirect, new AgentTurnContext(
                Instruction: "Redirect the learner back to the concept with a concrete small next step.",
                ConceptTitle: task.Title)),

            RouteKind.MetaHelp => (AgentKind.MetaHelp, new AgentTurnContext(
                Instruction: "Answer the learner's meta/procedural question: open with the progress line verbatim, then pivot to the remaining gap.",
                ProgressLine: route.ProgressLine,
                Target: ResolveTarget(record, route.NextTarget),
                ConceptTitle: task.Title)),

            RouteKind.Closing => (AgentKind.Closing, new AgentTurnContext(
                Instruction: route.Closing == ClosingReason.AllCovered
                    ? "reason=AllCovered. Acknowledge that the learner has covered the concept in 2 sentences max."
                    : "reason=HardCapReached. Acknowledge that the conversation is ending in 2 sentences max.",
                ConceptTitle: task.Title)),

            _ => throw new InvalidOperationException($"Unknown route kind: {route.Kind}")
        };

    private RouteDecision DecideRoute(
        ConversationAttempt attempt, ConceptRecord record,
        TurnIntent intent, TurnEvaluation? evaluation)
    {
        if (record.IsAttemptComplete(attempt))
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
                var progressLine = RenderProgressLine(attempt, record);
                var next = PickNextTarget(attempt, record);
                return RouteDecision.Meta(progressLine, next);
            }

            case TurnIntent.Stuck:
            {
                var next = PickNextTarget(attempt, record);
                if (next == null) return RouteDecision.Close(ClosingReason.AllCovered);
                var level = DeriveLevel(attempt, next);
                var directive = new ProbeDirective(next.Value.Type, next.Value.Key, Math.Max(level, ScaffoldingLevel));
                return RouteDecision.Scaffold(directive);
            }

            case TurnIntent.Substantive:
            {
                if (evaluation is { HasMultipleConcerns: true })
                    return RouteDecision.CritiqueFor(evaluation);

                var next = PickNextTarget(attempt, record);
                if (next == null) return RouteDecision.Close(ClosingReason.AllCovered);
                var level = DeriveLevel(attempt, next);
                var directive = new ProbeDirective(next.Value.Type, next.Value.Key, level);

                return level >= ScaffoldingLevel
                    ? RouteDecision.Scaffold(directive)
                    : RouteDecision.Probe(directive);
            }

            default:
                return RouteDecision.Redirect();
        }
    }

    private static (ProbeTargetType Type, string Key)? PickNextTarget(
        ConversationAttempt attempt, ConceptRecord record)
    {
        var uncoveredKp = record.GetUncoveredPropositionKeys(attempt);
        if (uncoveredKp.Count > 0)
            return (ProbeTargetType.KeyProposition, uncoveredKp.OrderBy(KeyOrder).First());

        var unarticulatedKr = record.GetUnarticulatedRelationKeys(attempt);
        return unarticulatedKr.Count > 0
            ? (ProbeTargetType.KeyRelation, unarticulatedKr.OrderBy(KeyOrder).First())
            : null;
    }

    private static int KeyOrder(string key)
    {
        // Natural keys are a single-letter prefix followed by digits (e.g., P1, R10, B3).
        return int.TryParse(key.AsSpan(1), out var n) ? n : int.MaxValue;
    }

    private static int DeriveLevel(
        ConversationAttempt attempt, (ProbeTargetType Type, string Key)? target)
    {
        if (target == null) return 1;
        var priorProbes = attempt.Turns.Count(t =>
            t.Role == TurnRole.System &&
            t.ProbeTargetType == target.Value.Type &&
            t.ProbeTargetKey == target.Value.Key);
        return priorProbes + 1;
    }

    private static ProbeDirective? FindLastProbe(ConversationAttempt attempt)
    {
        var last = attempt.Turns
            .Where(t => t.Role == TurnRole.System && t.ProbeTargetType.HasValue)
            .OrderByDescending(t => t.Order)
            .FirstOrDefault();
        if (last == null) return null;
        return new ProbeDirective(last.ProbeTargetType!.Value, last.ProbeTargetKey!, last.ProbeLevel!.Value);
    }

    private static string RenderProgressLine(ConversationAttempt attempt, ConceptRecord record)
    {
        var coveredKp = attempt.GetCoveredPropositionKeys().Count;
        var totalKp = record.KeyPropositions.Count;
        var articulatedKr = attempt.GetArticulatedRelationKeys().Count;
        var totalKr = record.KeyRelations.Count;

        return totalKr > 0
            ? $"Dosadašnji napredak: pokriveno {coveredKp}/{totalKp} ključnih izjava i {articulatedKr}/{totalKr} ključnih veza."
            : $"Dosadašnji napredak: pokriveno {coveredKp}/{totalKp} ključnih izjava.";
    }

    private static TargetDirective? ResolveTarget(ConceptRecord record, ProbeDirective? directive)
    {
        if (directive == null) return null;
        var statement = ResolveTargetStatement(record, directive);
        return new TargetDirective(directive.TargetType, directive.TargetKey, directive.Level, statement);
    }

    private static string ResolveTargetStatement(ConceptRecord record, ProbeDirective directive)
    {
        if (directive.TargetType == ProbeTargetType.KeyProposition)
        {
            var kp = record.KeyPropositions.FirstOrDefault(p => p.Key == directive.TargetKey);
            return kp?.Statement ?? "(unknown)";
        }
        var kr = record.KeyRelations.FirstOrDefault(r => r.Key == directive.TargetKey);
        if (kr == null) return "(unknown)";
        var kpByKey = record.KeyPropositions.ToDictionary(p => p.Key, p => p.Statement);
        var source = kpByKey.GetValueOrDefault(kr.SourceKey, "?");
        var target = kpByKey.GetValueOrDefault(kr.TargetKey, "?");
        return $"{source} → {target}. Mechanism: {kr.Mechanism}";
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
        public static RouteDecision Meta(string progressLine, (ProbeTargetType Type, string Key)? next)
        {
            var nextDirective = next == null ? null : new ProbeDirective(next.Value.Type, next.Value.Key, 1);
            return new RouteDecision(RouteKind.MetaHelp, ProgressLine: progressLine, NextTarget: nextDirective);
        }
        public static RouteDecision Close(ClosingReason reason) => new(RouteKind.Closing, Closing: reason);
    }
}
