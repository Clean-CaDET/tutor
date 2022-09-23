using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents
{
    public class AssessmentItemAnswered : AssessmentItemEvent
    {
        public Submission Submission { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}
