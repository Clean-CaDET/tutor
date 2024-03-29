
namespace Tutor.LearningTasks.API.Dtos.LearningTaskProgress;

public class StepProgressDto
{
    public int Id { get; set; }
    public string? Answer { get; set; }
    public string? Status { get; set; }
    public int StepId { get; set; }
}
