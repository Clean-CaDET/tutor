using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.AssessmentItemMasteries
{
    public class SolutionRequest : AssessmentItemInteraction
    {
        public SolutionRequest(int assessmentItemId) : base(assessmentItemId)
        {
        }

        internal override AssessmentItemEvent CreateEvent()
        {
            return new SoughtSolution()
            {
                AssessmentItemId = AssessmentItemId
            };
        }
    }
}
