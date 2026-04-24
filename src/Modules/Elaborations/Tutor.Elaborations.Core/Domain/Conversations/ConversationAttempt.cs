using System.Dynamic;
using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class ConversationAttempt : AggregateRoot
{
    public int ConceptElaborationTaskId { get; private set; }
    public int LearnerId { get; private set; }
    public AttemptStatus Status { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public string? Summary { get; private set; }
    public List<ConversationTurn> Turns { get; private set; } = new();
    public int? SoftCapTotalTurns { get; private set; }
    public int? HardCapTotalTurns { get; private set; }

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

    public ConversationTurn AddLearnerTurn(string content, TurnIntent intent, TurnEvaluation? evaluation)
    {
        var turn = new ConversationTurn(TurnRole.Learner, content, Turns.Count, intent, evaluation);
        Turns.Add(turn);
        return turn;
    }

    public ConversationTurn AddSystemTurn(string content, ProbeDirective? probeDirective = null)
    {
        var turn = new ConversationTurn(TurnRole.System, content, Turns.Count,
            intent: null, evaluation: null, probeDirective: probeDirective);
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
}
