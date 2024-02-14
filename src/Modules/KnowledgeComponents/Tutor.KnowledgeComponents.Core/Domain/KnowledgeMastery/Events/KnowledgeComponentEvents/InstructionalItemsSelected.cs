namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

public class InstructionalItemsSelected : KnowledgeComponentEvent
{
    public string? AppClientId { get; set; }
}