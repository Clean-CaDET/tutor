using Microsoft.EntityFrameworkCore;
using Tutor.LearningTasks.Core.Domain;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Infrastructure.Database.Repositories;

public class TaskConversationDatabaseRepository : ITaskConversationRepository
{
    private readonly LearningTasksContext _dbContext;

    public TaskConversationDatabaseRepository(LearningTasksContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TaskConversation? GetMostRecentByLearningTaskId(int learningTaskId, int learnerId)
    {
        return _dbContext.TaskConversations
            .Where(c => c.LearningTaskId == learningTaskId && c.LearnerId == learnerId)
            .OrderByDescending(c => c.CreatedAt)
            .FirstOrDefault();
    }

    public TaskConversation? GetById(int conversationId)
    {
        return _dbContext.TaskConversations
            .FirstOrDefault(c => c.Id == conversationId);
    }

    public TaskConversation Add(TaskConversation conversation)
    {
        _dbContext.TaskConversations.Add(conversation);
        return conversation;
    }

    public void Update(TaskConversation conversation)
    {
        _dbContext.TaskConversations.Attach(conversation);
        _dbContext.Entry(conversation).State = EntityState.Modified;
    }
}