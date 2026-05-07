using FluentResults;
using Tutor.Elaborations.API.Dtos.ConceptElaborationTasks;
using Tutor.Elaborations.API.Dtos.Conversations;

namespace Tutor.Elaborations.API.Public.Learning;

public interface IConversationService
{
    Result<List<LearnerElaborationSummaryDto>> GetTasksForUnit(int unitId, int learnerId);
    Result<ConceptElaborationTaskDto> GetTaskWithAttempts(int taskId, int learnerId);
    IAsyncEnumerable<string> StartConversationAsync(int taskId, string elaboration, int learnerId, CancellationToken ct);
    IAsyncEnumerable<string> SubmitElaborationAsync(int attemptId, string elaboration, int learnerId, CancellationToken ct);
    Result<ConversationAttemptDto> AbandonAttempt(int attemptId, int learnerId);
}
