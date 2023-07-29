using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

namespace Tutor.LanguageModelConversations.Infrastructure.Database.Repositories;

public class TokenDatabaseRepository : ITokenRepository
{
    private readonly LanguageModelConversationsContext _dbContext;

    public TokenDatabaseRepository(LanguageModelConversationsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Token? GetByLearner(int learnerId)
    {
        return _dbContext.Tokens
            .Where(t => t.LearnerId == learnerId)
            .FirstOrDefault();
    }

    public Token Create(Token token)
    {
        _dbContext.Tokens.Add(token);
        return token;
    }

    public Token UpdateIfExisting(Token token)
    {
        if (_dbContext.Entry(token).State == EntityState.Added) return token;
        _dbContext.Tokens.Update(token);
        return token;
    }
}
