namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.CodeCompletionQuestions;

public class CcqEvaluationDto : EvaluationDto
{
    public List<CcqItemDto> Items { get; set; }
    public string Feedback { get; set; }
}