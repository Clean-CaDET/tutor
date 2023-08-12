namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiChoiceQuestions;

public class McqEvaluationDto : EvaluationDto
{
    public string CorrectAnswer { get; set; }
    public string Feedback { get; set; }
}