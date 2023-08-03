namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqItemEvaluationDto
{
    public string Text { get; set; }
    public string Feedback { get; set; }
    public bool SubmissionWasCorrect { get; set; }
}