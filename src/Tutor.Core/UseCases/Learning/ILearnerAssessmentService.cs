using FluentResults;
using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.UseCases.Learning
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