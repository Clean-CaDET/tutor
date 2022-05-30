using System;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class AssessmentItemMastery: Entity
    {
        public int AssessmentItemId { get; private set; }
        public double Mastery { get; private set; }
        public int SubmissionCount { get; private set; }
        public DateTime? LastSubmissionTime { get; set; }
        public void UpdateMastery(AssessmentItemAnswered answer)
        {
            if (Mastery <= answer.Evaluation.CorrectnessLevel) Mastery = answer.Evaluation.CorrectnessLevel;
            SubmissionCount++;
            LastSubmissionTime = answer.TimeStamp;
        }

        public bool IsAttempted()
        {
            return SubmissionCount > 0;
        }
    }
}