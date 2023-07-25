namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.ShortAnswerQuestions;

public class SaqEvaluationDto : EvaluationDto
{
    public List<string> AcceptableAnswers { get; set; }
    public string Feedback { get; set; }
}