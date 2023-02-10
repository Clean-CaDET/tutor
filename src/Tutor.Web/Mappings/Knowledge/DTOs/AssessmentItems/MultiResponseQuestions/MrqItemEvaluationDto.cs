namespace Tutor.Web.Mappings.Knowledge.DTOs.AssessmentItems.MultiResponseQuestions;

public class MrqItemEvaluationDto
{
    public string Text { get; set; }
    public string Feedback { get; set; }
    public bool SubmissionWasCorrect { get; set; }
}