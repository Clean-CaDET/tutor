using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.AssessmentItemMasteries
{
    public abstract class AssessmentItemInteraction
    {
        public int AssessmentItemId { get; }

        protected AssessmentItemInteraction(int assessmentItemId)
        {
            AssessmentItemId = assessmentItemId;
        }

        internal abstract AssessmentItemEvent CreateEvent();
    }
}
