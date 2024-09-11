namespace Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

public class InternalKcUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int SatisfiedCount { get; set; }
    public List<InternalKcProgressStatisticsDto> SatisfiedKcStatistics { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        return Equals((InternalKcUnitSummaryStatisticsDto)obj);
    }

    private bool Equals(InternalKcUnitSummaryStatisticsDto other)
    {
        if (UnitId != other.UnitId || TotalCount != other.TotalCount || SatisfiedCount != other.SatisfiedCount) return false;
        if (SatisfiedKcStatistics.Count != other.SatisfiedKcStatistics.Count) return false;
        if (!other.SatisfiedKcStatistics.All(SatisfiedKcStatistics.Contains)) return false;
        return true;
    }
}