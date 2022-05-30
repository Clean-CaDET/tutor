using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents
{
    public class AssessmentItemAnswered : KnowledgeComponentEvent
    {
        public int AssessmentItemId { get; set; }
        public Submission Submission { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}
