using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class TurnEvaluation : Entity
{
    public int ConversationRoundId { get; private set; }
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

    public List<ScoredTarget> GetDeficientTargets(List<FeedbackTarget> excludedProbes)
    {
        var misconceptionTargets = MisconceptionsTriggeredKeys.Select(key => new ScoredTarget(key, TargetType.Misconception, -2));
        var unfinishedTargets = Assessments.Where(a => a.Grade < 2);

        return unfinishedTargets.Concat(misconceptionTargets)
            .Where(a => excludedProbes.All(p => !p.ScoredTarget.SameTarget(a)))
            .OrderBy(t => t.SeverityRank())
            .ToList();
    }
}
