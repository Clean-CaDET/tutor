using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class ConversationAttempt : AggregateRoot
{
    private const int ProbeLadderLength = 2;
    private const int ScaffoldLadderLength = 2;
    private const int StalledThreshold = ProbeLadderLength + ScaffoldLadderLength;

    public int ConceptElaborationTaskId { get; private set; }
    public int LearnerId { get; private set; }
    public AttemptStatus Status { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public string? Summary { get; private set; }
    private List<ConversationTurn> _turns = new();
    public IReadOnlyList<ConversationTurn> Turns => _turns.AsReadOnly();
    public int? SoftCapTotalTurns { get; private set; }
    public int? HardCapTotalTurns { get; private set; }
    public int? ClosingTurnCount { get; private set; }

    private ConversationAttempt() { }

    public ConversationAttempt(int conceptElaborationTaskId, int learnerId, int totalItems)
    {
        ConceptElaborationTaskId = conceptElaborationTaskId;
        LearnerId = learnerId;
        Status = AttemptStatus.InProgress;
        StartedAt = DateTime.UtcNow;
        HardCapTotalTurns = totalItems + 2;
        SoftCapTotalTurns = Math.Max(totalItems - 2, 2);
    }

    public ISet<string> GetArticulatedPropositionKeys()
    {
        return Turns
            .Where(t => t.Evaluation != null)
            .SelectMany(t => t.Evaluation!.PropositionsCoveredKeys)
            .ToHashSet();
    }

    public ISet<string> GetArticulatedRelationKeys()
    {
        return Turns
            .Where(t => t.Evaluation != null)
            .SelectMany(t => t.Evaluation!.RelationsArticulatedKeys)
            .ToHashSet();
    }

    public int CountTotalLearnerTurns()
    {
        return Turns.Count(t => t.Role == TurnRole.Learner);
    }

    public bool IsSoftCapReached() => CountTotalLearnerTurns() >= SoftCapTotalTurns;

    public bool IsHardCapReached() => CountTotalLearnerTurns() >= HardCapTotalTurns;

    public int GetProbeLevelFor(string target)
    {
        var max = Turns
            .Where(t => t.Role == TurnRole.System && t.ProbeTarget == target && t.ProbeLevel.HasValue)
            .Select(t => t.ProbeLevel!.Value)
            .DefaultIfEmpty(0)
            .Max();
        return max + 1;
    }

    public ProbeDirective? GetLastProbe()
    {
        var last = Turns
            .Where(t => t.Role == TurnRole.System && t.ProbeTarget != null)
            .OrderByDescending(t => t.Order)
            .FirstOrDefault();
        if (last == null) return null;
        return new ProbeDirective(last.ProbeTarget!, last.ProbeLevel!.Value);
    }

    public bool IsScaffolding(int ladderLevel) => ladderLevel > ProbeLadderLength;

    public int FirstScaffoldLadderLevel => ProbeLadderLength + 1;

    public IReadOnlySet<string> GetStalledTargets()
    {
        return Turns
            .Where(t => t.Role == TurnRole.System && t.ProbeTarget != null && t.ProbeLevel >= StalledThreshold)
            .Select(t => t.ProbeTarget!)
            .ToHashSet();
    }

    public int CountNonSubstantiveClosingTurns()
    {
        if (ClosingTurnCount == null) return 0;
        return Turns
            .Skip(ClosingTurnCount.Value)
            .Count(t => t.Role == TurnRole.Learner && t.Intent != TurnIntent.Substantive);
    }

    public ConversationTurn AddLearnerTurn(string content, TurnIntent intent, TurnEvaluation? evaluation)
    {
        var turn = new ConversationTurn(TurnRole.Learner, content, _turns.Count, intent, evaluation);
        _turns.Add(turn);
        return turn;
    }

    public ConversationTurn AddSystemTurn(string content, ProbeDirective? probeDirective = null)
    {
        var turn = new ConversationTurn(TurnRole.System, content, _turns.Count,
            intent: null, evaluation: null, probeDirective: probeDirective);
        _turns.Add(turn);
        return turn;
    }

    public void TransitionToClosing(string closingMessage)
    {
        AddSystemTurn(closingMessage);
        Status = AttemptStatus.InClosing;
        ClosingTurnCount = _turns.Count;
    }

    public void Complete(TurnEvaluation evaluation)
    {
        Summary = $"{evaluation.Grade()} / 10";
        AddSystemTurn(Summary);
        Status = AttemptStatus.Completed;
        CompletedAt = DateTime.UtcNow;
    }

    public void Abandon()
    {
        Status = AttemptStatus.Abandoned;
        CompletedAt = DateTime.UtcNow;
    }

    public void Expire(string? summary)
    {
        Status = AttemptStatus.Expired;
        CompletedAt = DateTime.UtcNow;
        Summary = summary;
    }
}
