using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class AssessmentItemMastery : EventSourcedEntity
    {
        public int AssessmentItemId { get; private set; }
        public double Mastery { get; private set; }
        public int SubmissionCount { get; private set; }
        public DateTime? LastSubmissionTime { get; set; }

        public bool IsAttempted()
        {
            return SubmissionCount > 0;
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
        }

        private void When(AssessmentItemAnswered @event)
        {
            if (Mastery <= @event.Evaluation.CorrectnessLevel) Mastery = @event.Evaluation.CorrectnessLevel;
            SubmissionCount++;
            LastSubmissionTime = @event.TimeStamp;
        }
    }
}