using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.DomainModel.KnowledgeComponents.Events.KnowledgeComponentEvents
{
    public abstract class KnowledgeComponentEvent : DomainEvent
    {
        public int KnowledgeComponentId { get; set; }
        public int LearnerId { get; set; }
    }
}
