using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.AssessmentItemMasteries
{
    public class HintRequest : AssessmentItemInteraction
    {
        public HintRequest(int assessmentItemId) : base(assessmentItemId)
        {
        }

        internal override AssessmentItemEvent CreateEvent()
        {
            return new SoughtHints()
            {
                AssessmentItemId = AssessmentItemId,
            };
        }
    }
}
