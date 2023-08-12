namespace Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

public class AiStatisticsDto
{
    public int KcId { get; set; }
    public int AiId { get; set; }
    public int TotalCompleted { get; set; }
    public int TotalPassed { get; set; }
    public List<double> MinutesToCompletion { get; set; }
    public List<int> AttemptsToPass { get; set; }

    public override int GetHashCode()
    {
        return AiId.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not AiStatisticsDto other) return false;
        return AiId == other.AiId
               && TotalCompleted == other.TotalCompleted
               && TotalPassed == other.TotalPassed
               && MinutesToCompletion.Count == other.MinutesToCompletion.Count
               && MinutesToCompletion.All(other.MinutesToCompletion.Contains)
               && AttemptsToPass.Count == other.AttemptsToPass.Count
               && AttemptsToPass.All(other.AttemptsToPass.Contains);
    }
}