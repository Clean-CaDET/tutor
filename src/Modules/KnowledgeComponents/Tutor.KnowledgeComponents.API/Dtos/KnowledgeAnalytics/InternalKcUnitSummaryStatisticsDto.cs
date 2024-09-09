namespace Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;

public class InternalKcUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int SatisfiedCount { get; set; }
    public List<InternalKcProgressStatisticsDto> KcProgressStatistics { get; set; }
}