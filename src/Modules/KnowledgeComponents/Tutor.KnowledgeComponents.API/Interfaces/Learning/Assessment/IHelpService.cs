using FluentResults;

namespace Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;

public interface IHelpService
{
    Result RecordHintRequest(int learnerId, int assessmentItemId);
    Result RecordInstructorMessage(int learnerId, int kcId, string message);
}