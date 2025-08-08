using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.Events;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Infrastructure.Database.Repositories;

public class WalletDatabaseRepository : IWalletRepository
{
    private readonly StakeholdersContext _dbContext;
    private readonly IEventStore<WalletEvent> _eventStore;

    public WalletDatabaseRepository(StakeholdersContext dbContext, IEventStore<WalletEvent> eventStore)
    {
        _dbContext = dbContext;
        _eventStore = eventStore;
    }

    public Wallet Create(Wallet wallet)
    {
        _dbContext.Wallets.Add(wallet);
        _eventStore.Save(wallet);
        return wallet;
    }

    public void Update(Wallet wallet)
    {
        _dbContext.Wallets.Attach(wallet);
        _eventStore.Save(wallet);
    }

    public Wallet? GetByLearnerId(int learnerId)
    {
        return _dbContext.Wallets
            .FirstOrDefault(w => w.LearnerId == learnerId);
    }

    public List<Wallet> GetByLearnerIds(List<int> learnerIds)
    {
        return _dbContext.Wallets
            .Where(w => learnerIds.Contains(w.LearnerId))
            .ToList();
    }
}