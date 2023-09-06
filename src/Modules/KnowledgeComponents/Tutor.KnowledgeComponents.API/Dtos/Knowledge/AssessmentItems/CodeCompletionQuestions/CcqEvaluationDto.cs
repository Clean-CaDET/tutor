namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqEvaluationDto : EvaluationDto
{
    public List<string> AcceptableAnswers { get; set; }
    public string Feedback { get; set; }
}