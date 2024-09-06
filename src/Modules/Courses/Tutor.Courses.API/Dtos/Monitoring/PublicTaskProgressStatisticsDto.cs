namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicTaskProgressStatisticsDto
{
    public int TotalCount { get; set; }
    public int CompletedCount { get; set; }
    public int LearnerPoints { get; set; }
    public int AvgGroupPoints { get; set; }
    public string[] NegativePatterns { get; set; }
}