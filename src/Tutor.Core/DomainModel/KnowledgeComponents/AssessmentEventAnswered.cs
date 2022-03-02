using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class AssessmentEventAnswered : DomainEvent
    {
        public Submission Submission { get; set; }
    }
}
