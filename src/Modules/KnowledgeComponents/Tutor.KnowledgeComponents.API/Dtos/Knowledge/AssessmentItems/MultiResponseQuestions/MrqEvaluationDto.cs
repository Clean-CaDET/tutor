namespace Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems.MultiResponseQuestions;

public class MrqEvaluationDto : EvaluationDto
{
    public List<MrqItemEvaluationDto> ItemEvaluations { get; set; }
}