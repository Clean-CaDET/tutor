namespace Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

public interface ITokenWalletRepository
{
    TokenWallet? GetByLearnerAndCourse(int learnerId, int courseId);
    TokenWallet Create(TokenWallet token);
    TokenWallet UpdateIfExisting(TokenWallet token);
}
