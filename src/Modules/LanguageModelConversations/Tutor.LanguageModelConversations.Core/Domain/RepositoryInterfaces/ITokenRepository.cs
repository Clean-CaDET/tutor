namespace Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

public interface ITokenRepository
{
    TokenWallet? GetByLearner(int learnerId);
    TokenWallet Create(TokenWallet token);
    TokenWallet UpdateIfExisting(TokenWallet token);
}
