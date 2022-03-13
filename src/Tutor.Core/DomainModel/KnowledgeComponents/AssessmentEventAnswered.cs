using Tutor.Core.BuildingBlocks.EventSourcing;

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
