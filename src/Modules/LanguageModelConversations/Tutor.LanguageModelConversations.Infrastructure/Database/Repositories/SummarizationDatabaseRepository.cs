using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

namespace Tutor.LanguageModelConversations.Infrastructure.Database.Repositories;

public class SummarizationDatabaseRepository : ISummarizationRepository
{
    private readonly LanguageModelConversationsContext _dbContext;

    public SummarizationDatabaseRepository(LanguageModelConversationsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Summarization? GetByContextIdAndGroup(int contextId, ContextGroup group)
    {
        return _dbContext.Summarizations
            .Where(s => s.ContextId == contextId && s.Group == group)
            .FirstOrDefault();
    }

    public Summarization Create(Summarization summarization)
    {
        _dbContext.Summarizations.Add(summarization);
        return summarization;
    }
}
