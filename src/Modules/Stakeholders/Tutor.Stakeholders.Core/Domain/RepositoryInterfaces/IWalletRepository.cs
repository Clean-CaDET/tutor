namespace Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

public interface IWalletRepository
{
    Wallet Create(Wallet wallet);
    void Update(Wallet wallet);
    Wallet? GetByLearnerId(int learnerId);
    List<Wallet> GetByLearnerIds(List<int> learnerIds);
}