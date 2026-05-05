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

    public bool HasBroadCoverage(int totalRubricItems) =>
        totalRubricItems > 0 && Assessments.Count(a => a.Grade >= 2) / (double)totalRubricItems >= 0.8;

    private TurnEvaluation() { }

    public TurnEvaluation(List<ScoredTarget> assessments, List<string> misconceptionsTriggeredKeys, bool hasMultipleConcerns)
    {
        Assessments = assessments;
        MisconceptionsTriggeredKeys = misconceptionsTriggeredKeys;
        HasMultipleConcerns = hasMultipleConcerns;
    }

    public int ComputeGrade(int totalTargets)
    {
        var actualScore = Assessments.Sum(a => a.Grade) - MisconceptionsTriggeredKeys.Count;
        var maxScore = 3.0 * totalTargets;
        return Math.Max((int)Math.Round(actualScore / maxScore * 10), 0);
    }
}
