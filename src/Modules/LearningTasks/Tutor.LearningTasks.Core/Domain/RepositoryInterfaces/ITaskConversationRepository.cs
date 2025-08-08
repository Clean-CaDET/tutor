namespace Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

public interface ITaskConversationRepository
{
    TaskConversation? GetMostRecentByLearningTaskId(int learningTaskId, int learnerId);
    TaskConversation? GetById(int conversationId);
    TaskConversation Add(TaskConversation conversation);
    void Update(TaskConversation conversation);
}