using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class InstructionalEventsSelected : DomainEvent
    {
        public int KnowledgeComponentId { get; set; }
        public int LearnerId { get; set; }
    }
}
