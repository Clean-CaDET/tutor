using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class AssessmentEventSelected : DomainEvent
    {
        public int LearnerId { get; set; }
        public int KnowledgeComponentId { get; set; }
        public int AssessmentEventId { get; set; }
    }
}
