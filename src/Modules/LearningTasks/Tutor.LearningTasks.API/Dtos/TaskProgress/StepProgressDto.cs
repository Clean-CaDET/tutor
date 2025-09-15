namespace Tutor.LearningTasks.API.Dtos.TaskProgress;

public class StepProgressDto
{
    public int Id { get; set; }
    public string? Answer { get; set; }
    public string? CommentForMentor { get; set; }
    public string? Status { get; set; }
    public int StepId { get; set; }
    public List<StandardEvaluationDto>? Evaluations { get; set; }
    public string? Comment { get; set; }
}
