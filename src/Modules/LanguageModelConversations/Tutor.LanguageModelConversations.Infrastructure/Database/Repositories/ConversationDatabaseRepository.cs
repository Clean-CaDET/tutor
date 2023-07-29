using Microsoft.EntityFrameworkCore;
using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

namespace Tutor.LanguageModelConversations.Infrastructure.Database.Repositories;

public class ConversationDatabaseRepository : IConversationRepository
{
    private readonly LanguageModelConversationsContext _dbContext;

    public ConversationDatabaseRepository(LanguageModelConversationsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Conversation? Get(int id)
    {
        return _dbContext.Conversations.Find(id);
    }

    public Conversation? GetByLearnerAndContext(int learnerId, int contextId)
    {
        return _dbContext.Conversations
            .Where(c => c.LearnerId == learnerId && c.ContextId == contextId)
            .FirstOrDefault();
    }
    public Conversation Create(Conversation conversation)
    {
        _dbContext.Conversations.Add(conversation);
        return conversation;
    }

    public Conversation UpdateIfExisting(Conversation conversation)
    {
        if (_dbContext.Entry(conversation).State == EntityState.Added)
            return conversation;
        _dbContext.Conversations.Update(conversation);
        return conversation;
    }
}
