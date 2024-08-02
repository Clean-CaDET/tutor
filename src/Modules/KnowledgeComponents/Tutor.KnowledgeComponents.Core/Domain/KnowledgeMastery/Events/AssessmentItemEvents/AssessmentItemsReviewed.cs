namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

public class AssessmentItemsReviewed : KnowledgeComponentEvent
{
    public string? AppClientId { get; set; }
}