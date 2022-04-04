using FluentResults;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public interface ISubmissionService
    {
        Result<Evaluation> EvaluateAndSaveSubmission(Submission submission);
        Result<double> GetMaxCorrectness(int aeId, int learnerId);
    }
}