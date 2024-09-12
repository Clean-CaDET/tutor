namespace Tutor.LearningTasks.API.Dtos.TaskProgress;

public class TaskProgressDto
{
    public int Id { get; set; }
    public double TotalScore { get; set; }
    public required string Status { get; set; }
    public List<StepProgressDto>? StepProgresses { get; set; }
    public int LearningTaskId { get; set; }
    public int LearnerId { get; set; }
}
