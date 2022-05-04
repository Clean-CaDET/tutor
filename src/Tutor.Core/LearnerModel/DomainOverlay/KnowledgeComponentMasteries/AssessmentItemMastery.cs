using System;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class AssessmentItemMastery: Entity
    {
        public int AssessmentItemId { get; private set; }
        public double Mastery { get; private set; }
        public int SubmissionCount { get; private set; }
        public DateTime? LastSubmissionTime { get; set; }
        public void UpdateMastery(Submission newSubmission)
        {
            if (Mastery <= newSubmission.CorrectnessLevel) Mastery = newSubmission.CorrectnessLevel;
            SubmissionCount++;
            LastSubmissionTime = newSubmission.TimeStamp;
        }
    }
}