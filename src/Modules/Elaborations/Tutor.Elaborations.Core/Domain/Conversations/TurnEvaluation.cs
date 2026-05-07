using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class TurnEvaluation : Entity
{
    public int ConversationTurnId { get; private set; }
    public List<ScoredTarget> Assessments { get; private set; } = [];
    public List<string> MisconceptionsTriggeredKeys { get; private set; } = [];

    private TurnEvaluation() { }

    public TurnEvaluation(List<ScoredTarget> assessments, List<string> misconceptionsTriggeredKeys)
    {
        Assessments = assessments;
        MisconceptionsTriggeredKeys = misconceptionsTriggeredKeys;
    }

    public int TotalScore() => Assessments.Sum(a => a.Grade);

    public double ComputeGrade(int totalTargets)
    {
        var normalizedScore = Assessments.Sum(a => a.Grade) / (2.0 * totalTargets);
        return Math.Round(Math.Max(0.0, normalizedScore - 0.2 * MisconceptionsTriggeredKeys.Count), 2);
    }
}
