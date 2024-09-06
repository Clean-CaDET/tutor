namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicKcProgressStatisticsDto
{
    public int TotalCount { get; set; }
    public int SatisfiedCount { get; set; }
    public string[] NegativeInstructionalPatterns { get; set; }
    public string[] NegativeAssessmentPatterns { get; set; }
}