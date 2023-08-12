namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

public class KnowledgeComponentCompleted : KnowledgeComponentEvent
{
    public double MinutesToCompletion { get; set; }
}