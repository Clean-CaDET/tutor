using FluentResults;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;

namespace Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;

public interface IEvaluationService
{
    Result<FeedbackDto> EvaluateAssessmentItemSubmission(int assessmentItemId, SubmissionDto submission, int learnerId);
}