namespace Tutor.Courses.API.Dtos.Monitoring;

public class UnitProgressStatisticsDto
{
    public int UnitId { get; set; }
    public PublicKcUnitSummaryStatisticsDto KcStatistics { get; set; }
    public PublicTaskUnitSummaryStatisticsDto TaskStatistics { get; set; }
}