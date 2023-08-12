namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

public class EncouragingMessageSent : KnowledgeComponentEvent
{
    public string Message { get; set; }
}