using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.AssessmentItemMasteries
{
    public class AnswerSubmission : AssessmentItemInteraction
    {
        public Submission Submission { get; set; }
        public Evaluation Evaluation { get; set; }

        public AnswerSubmission(int assessmentItemId, Submission submission, Evaluation evaluation) : base(assessmentItemId)
        {
            Submission = submission;
            Evaluation = evaluation;
        }

        internal override AssessmentItemEvent CreateEvent()
        {
            return new AssessmentItemAnswered()
            {
                AssessmentItemId = AssessmentItemId,
                Submission = Submission,
                Evaluation = Evaluation
            };
        }
    }
}
