namespace Tutor.Courses.API.Dtos.Monitoring;

public class PublicTaskProgressStatisticsDto
{
    public int TaskId { get; set; }
    public DateTime CompletionTime { get; set; }
    public bool IsGraded { get; set; }
    public double WonPoints { get; set; }
    public List<string> NegativePatterns { get; set; }
}