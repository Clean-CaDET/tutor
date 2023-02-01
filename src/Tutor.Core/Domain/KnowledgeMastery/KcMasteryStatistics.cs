using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.KnowledgeMastery;

public class KcMasteryStatistics : ValueObject
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

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Mastery;
        yield return TotalCount;
        yield return PassedCount;
        yield return AttemptedCount;
        yield return IsSatisfied;
    }
}