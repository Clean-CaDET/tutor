using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public interface IConversationAttemptRepository : ICrudRepository<ConversationAttempt>
{
    ConversationAttempt? GetActiveAttempt(int conceptElaborationTaskId, int learnerId);
    List<ConversationAttempt> GetByTaskAndLearner(int conceptElaborationTaskId, int learnerId);
    int CountRecentAttempts(int conceptElaborationTaskId, int learnerId, DateTime since);
    HashSet<int> GetTaskIdsWithCompletedAttempts(List<int> taskIds, int learnerId);
}
