namespace Tutor.LearningTasks.API.Dtos.TaskAnalytics;

public class InternalTaskProgressStatisticsDto
{
    public int TaskId { get; set; }
    public DateTime CompletionTime { get; set; }
    public int WonPoints { get; set; }
    public string[] NegativePatterns { get; set; }
}