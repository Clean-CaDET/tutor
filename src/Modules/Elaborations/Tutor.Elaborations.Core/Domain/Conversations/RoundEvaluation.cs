using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class RoundEvaluation : Entity
{
    public int ConversationRoundId { get; private set; }
    public List<ScoredTarget> Assessments { get; private set; } = [];
    public List<ScoredTarget> TriggeredMisconceptions { get; private set; } = [];

    private RoundEvaluation() { }

    public RoundEvaluation(List<ScoredTarget> assessments, List<ScoredTarget> triggeredMisconceptions)
    {
        Assessments = assessments;
        TriggeredMisconceptions = triggeredMisconceptions;
    }

    public int ComputeTotalScore() => Assessments.Sum(a => a.Grade);

    public double ComputeGrade(int totalTargets)
    {
        var normalizedScore = Assessments.Sum(a => a.Grade) / (2.0 * totalTargets);
        return Math.Round(Math.Max(0.0, normalizedScore - (0.2 * TriggeredMisconceptions.Count)), 2);
    }

    public List<ScoredTarget> GetDeficientTargets(List<Probe> excludedProbes)
    {
        var unfinishedTargets = Assessments.Where(a => a.Grade < 2);

        return unfinishedTargets.Concat(TriggeredMisconceptions)
            .Where(a => excludedProbes.All(p => !p.ScoredTarget.SameTarget(a)))
            .OrderBy(t => t.SeverityRank())
            .ToList();
    }
}
