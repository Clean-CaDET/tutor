using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class InteractedWithAssessmentEvent : DomainEvent
    {
        public int LearnerId { get; set; }
        public int AssessmentEventId { get; set; }
        public AssessmentEventInteraction Interaction { get; set; }
    }
}
