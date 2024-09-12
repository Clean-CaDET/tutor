namespace Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

public class InternalKcProgressStatisticsDto
{
    public int KcId { get; set; }
    public DateTime SatisfactionTime { get; set; }
    public List<string> NegativePatterns { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        return Equals((InternalKcProgressStatisticsDto)obj);
    }

    private bool Equals(InternalKcProgressStatisticsDto other)
    {
        if (KcId != other.KcId) return false;
        if (NegativePatterns.Count != other.NegativePatterns.Count) return false;
        if (!other.NegativePatterns.All(NegativePatterns.Contains)) return false;
        return true;
    }

    public override int GetHashCode()
    {
        return KcId.GetHashCode();
    }
}