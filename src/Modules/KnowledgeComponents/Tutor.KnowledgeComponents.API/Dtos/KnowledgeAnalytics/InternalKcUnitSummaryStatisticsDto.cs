namespace Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

public class InternalKcUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int SatisfiedCount { get; set; }
    public List<InternalKcProgressStatisticsDto> KcProgressStatistics { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        return Equals((InternalKcUnitSummaryStatisticsDto)obj);
    }

    private bool Equals(InternalKcUnitSummaryStatisticsDto other)
    {
        if (UnitId != other.UnitId || TotalCount != other.TotalCount || SatisfiedCount != other.SatisfiedCount) return false;
        if (KcProgressStatistics.Count != other.KcProgressStatistics.Count) return false;
        if (!other.KcProgressStatistics.All(KcProgressStatistics.Contains)) return false;
        return true;
    }
}