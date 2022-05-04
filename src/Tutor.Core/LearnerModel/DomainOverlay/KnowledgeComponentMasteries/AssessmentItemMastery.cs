using System;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class AssessmentItemMastery: Entity
    {
        public int AssessmentItemId { get; private set; }
        public double Mastery { get; private set; }
        public int SubmissionCount { get; private set; }
        public DateTime? LastSubmissionTime { get; set; }
        //TODO: Consider if we need Submission list.
        public void UpdateMastery(double newCorrectnessLevel)
        {
            Mastery = newCorrectnessLevel;
            SubmissionCount++;
        }
    }
}