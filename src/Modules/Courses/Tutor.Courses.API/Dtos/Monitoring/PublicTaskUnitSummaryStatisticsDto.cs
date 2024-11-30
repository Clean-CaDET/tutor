namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicTaskUnitSummaryStatisticsDto
{
    public int UnitId { get; set; }
    public int TotalCount { get; set; }
    public int GradedCount { get; set; }
    public int CompletedCount { get; set; }
    public double LearnerPoints { get; set; }
    public double AvgGroupPoints { get; set; }
    public double TotalMaxPoints { get; set; }
    public List<PublicTaskProgressStatisticsDto> TaskStatistics { get; set; }
}