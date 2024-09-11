namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicTaskUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int CompletedCount { get; set; }
    public int LearnerPoints { get; set; }
    public int AvgGroupPoints { get; set; }
    public List<PublicTaskProgressStatisticsDto> GradedTaskStatistics { get; set; }
}