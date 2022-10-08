using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public interface ILearnerAssessmentService
    {
        Result<Evaluation> SubmitAssessmentItemAnswer(int learnerId, int assessmentItemId, Submission submission);
        Result<double> GetMaxCorrectness(int learnerId, int assessmentItemId);
        Result RecordHintRequest(int learnerId, int assessmentItemId);
        Result RecordSolutionRequest(int learnerId, int assessmentItemId);
        Result RecordInstructorMessage(int learnerId, int kcId, string message);
    }
}