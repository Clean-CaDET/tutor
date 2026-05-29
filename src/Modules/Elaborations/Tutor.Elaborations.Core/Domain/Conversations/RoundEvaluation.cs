using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class RoundEvaluation : Entity
{
    public int ConversationRoundId { get; private set; }
    public List<ScoredTarget> Assessments { get; private set; } = [];

    private RoundEvaluation() { }

    public RoundEvaluation(List<ScoredTarget> assessments)
    {
        Assessments = assessments;
    }

    public int ComputeTotalScore() => Assessments.Sum(a => a.Grade);

    public double ComputeGrade(int totalTargets)
    {
        return Math.Round(Math.Max(0.0, Assessments.Sum(a => a.Grade) / (2.0 * totalTargets)), 2);
    }

    public List<ScoredTarget> GetDeficientTargets(List<Probe> excludedProbes)
    {
        return Assessments.Where(a => a.Grade < 2)
            .Where(a => excludedProbes.All(p => !p.ScoredTarget.SameTarget(a)))
            .OrderBy(t => t.SeverityRank())
            .ToList();
    }
}
