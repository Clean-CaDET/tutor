using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;
using Tutor.Stakeholders.Core.Domain.Events;

namespace Tutor.Stakeholders.Infrastructure.Database.EventStore;

public class PostgresStore<TEvent> : IEventStore<TEvent> where TEvent : DomainEvent
{
    private readonly StakeholdersContext _eventContext;
    private readonly IEventSerializer<TEvent> _eventSerializer;

    public PostgresStore(StakeholdersContext eventContext, IEventSerializer<TEvent> eventSerializer)
    {
        _eventContext = eventContext;
        _eventSerializer = eventSerializer;
    }

    public IEventQueryable<TEvent> Events => new PostgresEventQueryable<TEvent>(_eventContext.WalletEvents, _eventSerializer);

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
                    DomainEvent = _eventSerializer.Serialize((TEvent)e)
                };
            });
        _eventContext.WalletEvents.AddRange(eventsToSave);
        aggregate.ClearChanges();
    }

    public List<TEvent> GetEventsByUserAndPrimaryEntities(int userId, HashSet<int> primaryEntityIds)
    {
        return _eventContext.WalletEvents
            .Where(e => e.LearnerId == userId && primaryEntityIds.Contains(e.AggregateId))
            .AsNoTracking()
            .Select(e => e.DomainEvent)
            .ToList()
            .Select(_eventSerializer.Deserialize)
            .ToList();
    }
}