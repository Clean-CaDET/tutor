using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.DomainModel.KnowledgeComponents.Events.AssessmentItemEvents
{
    public class AssessmentItemAnswered : DomainEvent
    {
        public Submission Submission { get; set; }
    }
}
