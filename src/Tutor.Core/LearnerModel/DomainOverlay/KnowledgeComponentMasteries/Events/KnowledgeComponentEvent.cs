using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events
{
    public abstract class KnowledgeComponentEvent : DomainEvent
    {
        public int KnowledgeComponentId { get; set; }
        public int LearnerId { get; set; }
    }
}
