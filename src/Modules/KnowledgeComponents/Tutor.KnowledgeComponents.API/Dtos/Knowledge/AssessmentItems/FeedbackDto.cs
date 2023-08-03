namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

public class FeedbackDto
{
    public string Type { get; set; }
    public string Hint { get; set; }
    public EvaluationDto Evaluation { get; set; }
}