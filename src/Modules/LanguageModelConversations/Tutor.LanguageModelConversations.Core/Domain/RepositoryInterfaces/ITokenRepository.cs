namespace Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

public interface ITokenRepository
{
    Token? GetByLearner(int learnerId);
    Token Create(Token token);
    Token UpdateIfExisting(Token token);
}
