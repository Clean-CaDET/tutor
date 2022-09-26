using FluentResults;
using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class AssessmentItemMastery : EventSourcedEntity
    {
        private const double PassThreshold = 0.9;

        public int AssessmentItemId { get; private set; }
        public double Mastery { get; private set; }
        public int SubmissionCount { get; private set; }
        public DateTime? LastSubmissionTime { get; set; }
        public bool IsCompleted { get => SubmissionCount > 0; }
        public bool IsPassed { get => Mastery > PassThreshold; }

        public Result RecordInteraction(AssessmentItemEvent interaction)
        {
            Causes(interaction);
            return Result.Ok();
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

        private void When(AssessmentItemEvent @event)
        {
            // no action needed for AssessmentItemSelected and SoughtHelp
        }
    }
}