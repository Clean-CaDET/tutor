using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public interface IConversationAttemptRepository : ICrudRepository<ConversationAttempt>
{
    ConversationAttempt? GetActiveAttempt(int elaborationTaskId, int learnerId);
    List<ConversationAttempt> GetByTaskAndLearner(int elaborationTaskId, int learnerId);
    int CountRecentAttempts(int elaborationTaskId, int learnerId, DateTime since);
    HashSet<int> GetTaskIdsWithCompletedAttempts(List<int> taskIds, int learnerId);
}
