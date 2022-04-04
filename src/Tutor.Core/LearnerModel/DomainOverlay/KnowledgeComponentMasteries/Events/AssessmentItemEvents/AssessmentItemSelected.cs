using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents
{
    public class AssessmentItemSelected : DomainEvent
    {
        public int LearnerId { get; set; }
        public int KnowledgeComponentId { get; set; }
        public int AssessmentItemId { get; set; }
    }
}
