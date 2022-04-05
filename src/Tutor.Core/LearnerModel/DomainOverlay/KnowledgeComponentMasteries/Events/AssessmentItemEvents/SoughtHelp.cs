using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents
{
    public abstract class SoughtHelp : DomainEvent
    {
        public int LearnerId { get; set; }
        public int AssessmentItemId { get; set; }
    }
}
