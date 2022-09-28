using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.AssessmentItemMasteries
{
    public class Selection : AssessmentItemInteraction
    {
        public Selection(int assessmentItemId) : base(assessmentItemId)
        {
        }

        internal override AssessmentItemEvent CreateEvent()
        {
            return new AssessmentItemSelected()
            {
                AssessmentItemId = AssessmentItemId
            };
        }
    }
}
