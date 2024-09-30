namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicTaskUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int GradedCount { get; set; }
    public int LearnerPoints { get; set; }
    public int AvgGroupPoints { get; set; }
    public double TotalMaxPoints { get; set; }
    public List<PublicTaskProgressStatisticsDto> GradedTaskStatistics { get; set; }
}