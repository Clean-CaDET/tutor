using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class TurnEvaluation : Entity
{
    public int ConversationTurnId { get; private set; }
    public List<ScoredTarget> Assessments { get; private set; } = [];
    public List<string> MisconceptionsTriggeredKeys { get; private set; } = [];
    public bool HasMultipleConcerns { get; private set; }

    public IReadOnlyList<string> PropositionsCoveredKeys()
    {
        return Assessments.Where(a => a.Type == ScoredTargetType.Proposition && a.Grade == 3)
            .Select(a => a.Key).ToList();
    }

    public IReadOnlyList<string> RelationsArticulatedKeys()
    {
        return Assessments.Where(a => a.Type == ScoredTargetType.Relation && a.Grade == 3)
            .Select(a => a.Key).ToList();
    }

    private TurnEvaluation() { }

    public TurnEvaluation(List<ScoredTarget> assessments, List<string> misconceptionsTriggeredKeys, bool hasMultipleConcerns)
    {
        Assessments = assessments;
        MisconceptionsTriggeredKeys = misconceptionsTriggeredKeys;
        HasMultipleConcerns = hasMultipleConcerns;
    }
}
