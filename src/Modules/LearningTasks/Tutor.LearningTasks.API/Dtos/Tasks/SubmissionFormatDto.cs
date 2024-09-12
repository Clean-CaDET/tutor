namespace Tutor.LearningTasks.API.Dtos.Tasks;

public class SubmissionFormatDto
{
    public required string Type { get; set; }
    public string? ValidationRule { get; set; }
    public required string Guidelines { get; set; }
}