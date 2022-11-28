namespace Tutor.Core.Domain.KnowledgeMastery;

public class KcMasteryStatistics
{
    public double Mastery { get; }
    public int TotalCount { get; }
    public int PassedCount { get; }
    public int AttemptedCount { get; }
    public bool IsSatisfied { get; }

    public KcMasteryStatistics(double mastery, int totalCount, int passedCount, int attemptedCount, bool isSatisfied)
    {
        Mastery = mastery;
        TotalCount = totalCount;
        PassedCount = passedCount;
        AttemptedCount = attemptedCount;
        IsSatisfied = isSatisfied;
    }
}