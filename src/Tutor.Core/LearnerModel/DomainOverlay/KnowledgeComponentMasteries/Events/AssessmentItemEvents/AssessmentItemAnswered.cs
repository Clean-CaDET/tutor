using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents
{
    public class AssessmentItemAnswered : KnowledgeComponentEvent
    {
        public Submission Submission { get; set; }
    }
}
