using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public interface ILearnerAssessmentService
    {
        Result<Evaluation> EvaluateAndSaveSubmission(int learnerId, int assessmentItemId, Submission submission);
        Result<double> GetMaxCorrectness(int learnerId, int assessmentItemId);
        Result SeekChallengeHints(int learnerId, int assessmentItemId);
        Result SeekChallengeSolution(int learnerId, int assessmentItemId);
        Result SaveInstructorMessage(string message, int kcId, int learnerId);
    }
}