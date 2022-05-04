using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public interface ILearnerAssessmentService
    {
        Result<Evaluation> EvaluateAndSaveSubmission(Submission submission);
        Result<double> GetMaxCorrectness(int assessmentItemId, int learnerId);
        Result SeekChallengeHints(int learnerId, int assessmentItemId);
        Result SeekChallengeSolution(int learnerId, int assessmentItemId);
        Result SaveInstructorMessage(string message, int kcId, int learnerId);
    }
}