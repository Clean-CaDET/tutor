namespace Tutor.LearningTasks.API.Dtos.LearningTasks;

public class SubmissionFormatDto
{
    public required string Type { get; set; }
    public string? AnswerValidation { get; set; }
    public required string Guidelines { get; set; }
}