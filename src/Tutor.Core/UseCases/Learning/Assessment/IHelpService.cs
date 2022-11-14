using FluentResults;

namespace Tutor.Core.UseCases.Learning.Assessment;

public interface IHelpService
{
    Result RecordHintRequest(int learnerId, int assessmentItemId);
    Result RecordSolutionRequest(int learnerId, int assessmentItemId);
    Result RecordInstructorMessage(int learnerId, int kcId, string message);
}