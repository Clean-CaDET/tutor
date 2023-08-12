namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

public class KnowledgeComponentPassed : KnowledgeComponentEvent
{
    public double MinutesToPass { get; set; }
}