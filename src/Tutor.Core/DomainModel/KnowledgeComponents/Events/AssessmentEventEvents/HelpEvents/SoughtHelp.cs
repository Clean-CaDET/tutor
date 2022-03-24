using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.DomainModel.KnowledgeComponents.Events.AssessmentEventEvents.HelpEvents
{
    public abstract class SoughtHelp : DomainEvent
    {
        public int LearnerId { get; set; }
        public int AssessmentEventId { get; set; }
    }
}
