using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;

public class KcStatistics : ValueObject
{
    public int KcId { get; init; }
    public int TotalRegistered { get; init; }
    public int TotalStarted { get; init; }
    public int TotalCompleted { get; init; }
    public int TotalPassed { get; init; }
    public List<double> MinutesToCompletion { get; init; }
    public List<double> MinutesToPass { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return KcId;
        yield return TotalCompleted;
        yield return TotalPassed;
        yield return TotalStarted;
        yield return TotalRegistered;
        foreach (var minutes in MinutesToCompletion)
        {
            yield return minutes;
        }
        foreach (var minutes in MinutesToPass)
        {
            yield return minutes;
        }
    }
}