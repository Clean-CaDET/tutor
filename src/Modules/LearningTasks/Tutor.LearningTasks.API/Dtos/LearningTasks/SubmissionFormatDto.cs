namespace Tutor.LearningTasks.API.Dtos.LearningTasks;

public class SubmissionFormatDto
{
    public required string Type { get; set; }
    public string? ValidationRule { get; set; }
    public required string Guidelines { get; set; }
}