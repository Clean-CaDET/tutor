namespace Tutor.LearningTasks.API.Dtos.TaskAnalytics;

public class InternalTaskProgressStatisticsDto
{
    public int TaskId { get; set; }
    public DateTime CompletionTime { get; set; }
    public double WonPoints { get; set; }
    public List<string> NegativePatterns { get; set; }
}