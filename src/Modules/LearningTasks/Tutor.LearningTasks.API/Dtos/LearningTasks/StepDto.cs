namespace Tutor.LearningTasks.API.Dtos.LearningTasks;

public class StepDto
{
    public int Id { get; set; }
    public int Order { get; set; }
    public int ActivityId { get; set; }
    public required string ActivityName { get; set; }
    public SubmissionFormatDto? SubmissionFormat { get; set; }
    public List<StandardDto>? Standards { get; set; }
    public double MaxPoints { get; set; }
}