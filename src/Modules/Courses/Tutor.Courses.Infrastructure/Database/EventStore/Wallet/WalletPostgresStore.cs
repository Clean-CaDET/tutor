using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;
using Tutor.Courses.Core.Domain.TokenWallet.Events;

namespace Tutor.Courses.Infrastructure.Database.EventStore.Wallet;

public class WalletPostgresStore<TEvent> : IEventStore<TEvent> where TEvent : DomainEvent
{
    private readonly CoursesContext _dbContext;
    private readonly IEventSerializer<TEvent> _eventSerializer;

    public WalletPostgresStore(CoursesContext dbContext, IEventSerializer<TEvent> eventSerializer)
    {
        _dbContext = dbContext;
        _eventSerializer = eventSerializer;
    }

    public IEventQueryable<TEvent> Events => new PostgresEventQueryable<TEvent>(_dbContext.WalletEvents, _eventSerializer);

    public void Save(EventSourcedAggregateRoot aggregate)
    {
        var aggregateType = aggregate.GetType().Name;

        var eventsToSave = aggregate.GetChanges().Select(
            e =>
            {
                var walletEvent = e as WalletEvent;
                return new StoredWalletDomainEvent
                {
                    AggregateType = aggregateType,
                    AggregateId = aggregate.Id,
                    TimeStamp = e.TimeStamp.ToUniversalTime(),
                    LearnerId = walletEvent?.LearnerId ?? 0,
                    CourseId = walletEvent?.CourseId ?? 0,
                    DomainEvent = _eventSerializer.Serialize((TEvent)e)
                };
            });
        _dbContext.WalletEvents.AddRange(eventsToSave);
        aggregate.ClearChanges();
    }

    public List<TEvent> GetEventsByUserAndPrimaryEntities(int userId, HashSet<int> primaryEntityIds)
    {
        return _dbContext.WalletEvents
            .Where(e => e.LearnerId == userId && primaryEntityIds.Contains(e.CourseId))
            .AsNoTracking()
            .Select(e => e.DomainEvent)
            .ToList()
            .Select(_eventSerializer.Deserialize)
            .ToList();
    }
}
