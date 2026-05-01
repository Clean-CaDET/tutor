using Tutor.BuildingBlocks.Core.Domain;

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
    private readonly List<ConversationTurn> _turns = new();
    public IReadOnlyList<ConversationTurn> Turns => _turns.AsReadOnly();
    public int? SoftCapTotalTurns { get; private set; }
    public int? HardCapTotalTurns { get; private set; }
    public int? ClosingTurnCount { get; private set; }

    private ConversationAttempt() { }

    public ConversationAttempt(int conceptElaborationTaskId, int learnerId, int totalTargets)
    {
        ConceptElaborationTaskId = conceptElaborationTaskId;
        LearnerId = learnerId;
        Status = AttemptStatus.InProgress;
        StartedAt = DateTime.UtcNow;
        HardCapTotalTurns = totalTargets + 4;
        SoftCapTotalTurns = Math.Max(totalTargets, 3);
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
            .Where(t => t.Role == TurnRole.System && t.Probe?.Target == target)
            .Select(t => t.Probe!.Level)
            .DefaultIfEmpty(0)
            .Max();
        return max + 1;
    }

    public ActiveProbe? GetLastProbe()
    {
        return Turns
            .Where(t => t.Role == TurnRole.System && t.Probe != null)
            .OrderByDescending(t => t.Order)
            .Select(t => t.Probe)
            .FirstOrDefault();
    }

    public bool IsScaffolding(int ladderLevel) => ladderLevel > ProbeLadderLength;

    public int FirstScaffoldLadderLevel => ProbeLadderLength + 1;

    public IReadOnlySet<string> GetStalledTargets()
    {
        return Turns
            .Where(t => t.Role == TurnRole.System && t.Probe != null && t.Probe.Level >= StalledThreshold)
            .Select(t => t.Probe!.Target)
            .ToHashSet();
    }

    public int CountNonSubstantiveClosingTurns()
    {
        if (ClosingTurnCount == null) return 0;
        return Turns
            .Skip(ClosingTurnCount.Value)
            .Count(t => t.Role == TurnRole.Learner && t.Intent != TurnIntent.Substantive);
    }

    public ConversationTurn AddLearnerTurn(string content, TurnIntent intent, TurnEvaluation? evaluation = null)
    {
        var turn = new ConversationTurn(TurnRole.Learner, content, _turns.Count, intent, evaluation);
        _turns.Add(turn);
        return turn;
    }

    public ConversationTurn AddSystemTurn(string content, ActiveProbe? probe = null)
    {
        var turn = new ConversationTurn(TurnRole.System, content, _turns.Count,
            intent: null, evaluation: null, probe: probe);
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

    public void Expire(string summary)
    {
        AddSystemTurn(summary);
        Status = AttemptStatus.Expired;
        CompletedAt = DateTime.UtcNow;
        Summary = summary;
    }
}
