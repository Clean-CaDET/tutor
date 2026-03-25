using FluentResults;
using Tutor.Elaborations.API.Dtos.Conversations;

namespace Tutor.Elaborations.API.Public.Learning;

public interface IConversationService
{
    Result<List<ElaborationTaskDto>> GetTasksForUnit(int unitId, int learnerId);
    IAsyncEnumerable<string> SubmitTurnAsync(int taskId, string content, int learnerId, CancellationToken ct);
    Result<ConversationAttemptDto> AbandonAttempt(int attemptId, int learnerId);
    Result<ConversationAttemptDto> GetAttempt(int attemptId, int learnerId);
    Result<List<ConversationAttemptDto>> GetAttempts(int taskId, int learnerId);
}
