namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

public class AssessmentItemSelected : AssessmentItemEvent
{
    public string? AppClientId { get; set; }
}