using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class AssessmentEventAnswered : DomainEvent
    {
        public int AssessmentEventId { get; set; }
        public int LearnerId { get; set; }
        public bool IsCorrect { get; set; }
        public double CorrectnessLevel { get; set; }
    }
}
