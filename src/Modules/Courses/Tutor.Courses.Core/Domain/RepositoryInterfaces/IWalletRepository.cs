using Tutor.Courses.Core.Domain.TokenWallet;

namespace Tutor.Courses.Core.Domain.RepositoryInterfaces;

public interface IWalletRepository
{
    Wallet? Get(int learnerId, int courseId);
    void Create(Wallet wallet);
    void Update(Wallet wallet);
    List<Wallet> GetByCourse(int courseId);
    List<Wallet> GetByCourseAndLearners(int courseId, List<int> learnerIds);
}
