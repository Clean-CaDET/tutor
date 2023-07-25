using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;

public class AiStatistics : ValueObject
{
    public int KcId { get; init; }
    public int AiId { get; init; }
    public int TotalCompleted => MinutesToCompletion.Count;
    public int TotalPassed => AttemptsToPass.Count;
    public List<double> MinutesToCompletion { get; init; }
    public List<int> AttemptsToPass { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return KcId;
        yield return AiId;
        foreach (var minutes in MinutesToCompletion)
        {
            yield return minutes;
        }
    }
}