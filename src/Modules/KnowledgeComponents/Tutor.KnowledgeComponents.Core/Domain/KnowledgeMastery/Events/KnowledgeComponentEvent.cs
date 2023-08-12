using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;

public abstract class KnowledgeComponentEvent : DomainEvent
{
    public int KnowledgeComponentId { get; set; }
    public int LearnerId { get; set; }
}