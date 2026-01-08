using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Courses.Core.Domain.TokenWallet;

namespace Tutor.Courses.Infrastructure.Database.Repositories;

public class TokenWalletDatabaseRepository<TEvent> : IWalletRepository where TEvent : DomainEvent
{
    private readonly CoursesContext _dbContext;
    private readonly IEventStore<TEvent> _eventStore;

    public TokenWalletDatabaseRepository(CoursesContext dbContext, IEventStore<TEvent> eventStore)
    {
        _dbContext = dbContext;
        _eventStore = eventStore;
    }

    public Wallet? Get(int learnerId, int courseId)
    {
        return _dbContext.TokenWallets
            .FirstOrDefault(w => w.LearnerId == learnerId && w.CourseId == courseId);
    }

    public void Create(Wallet wallet)
    {
        _dbContext.TokenWallets.Add(wallet);
        _eventStore.Save(wallet);
    }

    public void Update(Wallet wallet)
    {
        _dbContext.TokenWallets.Attach(wallet);
        _eventStore.Save(wallet);
    }

    public List<Wallet> GetByCourse(int courseId)
    {
        var wallets = _dbContext.TokenWallets
            .Where(w => w.CourseId == courseId)
            .ToList();
        return wallets;
    }

    public List<Wallet> GetByCourseAndLearners(int courseId, List<int> learnerIds)
    {
        return _dbContext.TokenWallets
            .Where(w => w.CourseId == courseId && learnerIds.Contains(w.LearnerId))
            .ToList();
    }
}
