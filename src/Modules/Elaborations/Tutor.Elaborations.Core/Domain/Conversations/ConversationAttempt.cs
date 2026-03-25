using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class ConversationAttempt : AggregateRoot
{
    private const int SoftCapSubstantiveTurns = 6;
    private const int HardCapTotalTurns = 10;

    public int ElaborationTaskId { get; private set; }
    public int LearnerId { get; private set; }
    public AttemptStatus Status { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public string? Summary { get; private set; }
    public List<ConversationTurn> Turns { get; private set; } = new();

    private ConversationAttempt() { }

    public ConversationAttempt(int elaborationTaskId, int learnerId)
    {
        ElaborationTaskId = elaborationTaskId;
        LearnerId = learnerId;
        Status = AttemptStatus.InProgress;
        StartedAt = DateTime.UtcNow;
    }

    public ISet<int> GetCoveredPropositionIds()
    {
        return Turns
            .Where(t => t.Evaluation != null)
            .SelectMany(t => t.Evaluation!.PropositionsCoveredIds)
            .ToHashSet();
    }

    public int CountSubstantiveLearnerTurns()
    {
        return Turns.Count(t => t.Role == TurnRole.Learner && t.IsSubstantive);
    }

    public int CountTotalLearnerTurns()
    {
        return Turns.Count(t => t.Role == TurnRole.Learner);
    }

    public bool IsSoftCapReached() => CountSubstantiveLearnerTurns() >= SoftCapSubstantiveTurns;

    public bool IsHardCapReached() => CountTotalLearnerTurns() >= HardCapTotalTurns;

    public ConversationTurn AddLearnerTurn(string content,
        bool isSubstantive, TurnEvaluation? evaluation)
    {
        var turn = new ConversationTurn(TurnRole.Learner, content,
            isSubstantive, Turns.Count, evaluation);
        Turns.Add(turn);
        return turn;
    }

    public ConversationTurn AddSystemTurn(string content)
    {
        var turn = new ConversationTurn(TurnRole.System, content, true, Turns.Count);
        Turns.Add(turn);
        return turn;
    }

    public void Complete(string? summary)
    {
        Status = AttemptStatus.Completed;
        CompletedAt = DateTime.UtcNow;
        Summary = summary;
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

    public void Block()
    {
        Status = AttemptStatus.Blocked;
        CompletedAt = DateTime.UtcNow;
    }
}
