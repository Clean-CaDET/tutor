using FluentResults;
using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.UseCases.Learning.Assessment
{
    public interface IEvaluationService
    {
        Result<Evaluation> EvaluateAssessmentItemSubmission(int learnerId, int assessmentItemId, Submission submission);
    }
}