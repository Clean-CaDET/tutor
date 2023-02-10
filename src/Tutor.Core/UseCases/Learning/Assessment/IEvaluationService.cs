using FluentResults;
using Tutor.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.Core.UseCases.Learning.Assessment;

public interface IEvaluationService
{
    Result<Feedback> EvaluateAssessmentItemSubmission(int assessmentItemId, Submission submission, int learnerId);
}