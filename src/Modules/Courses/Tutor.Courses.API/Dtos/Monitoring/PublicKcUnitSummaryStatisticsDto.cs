namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicKcUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int SatisfiedCount { get; set; }
    public List<PublicKcProgressStatisticsDto> KcProgressStatistics { get; set; }
}