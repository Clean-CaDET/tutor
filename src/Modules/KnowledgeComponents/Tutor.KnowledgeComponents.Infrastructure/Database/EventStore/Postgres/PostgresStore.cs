using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.Postgres;

public class PostgresStore<TEvent> : IEventStore<TEvent> where TEvent : DomainEvent
{
    private readonly KnowledgeComponentsContext _eventContext;
    private readonly IEventSerializer<TEvent> _eventSerializer;

    public PostgresStore(KnowledgeComponentsContext eventContext, IEventSerializer<TEvent> eventSerializer)
    {
        _eventContext = eventContext;
        _eventSerializer = eventSerializer;
    }

    public IEventQueryable<TEvent> Events => new PostgresEventQueryable<TEvent>(_eventContext.Events, _eventSerializer);

    public void Save(EventSourcedAggregateRoot aggregate)
    {
        // class name is temporarily used as aggregate type until we choose a better approach
        var aggregateType = aggregate.GetType().Name;

        var eventsToSave = aggregate.GetChanges().Select(
            e =>
            {
                var kcEvent = e as KnowledgeComponentEvent;
                return new StoredKcDomainEvent
                {
                    AggregateType = aggregateType,
                    AggregateId = aggregate.Id,
                    TimeStamp = e.TimeStamp.ToUniversalTime(),
                    LearnerId = kcEvent?.LearnerId ?? 0,
                    KnowledgeComponentId = kcEvent?.KnowledgeComponentId ?? 0,
                    DomainEvent = _eventSerializer.Serialize((TEvent)e)
                };
            });
        _eventContext.Events.AddRange(eventsToSave);
        aggregate.ClearChanges();
    }

    public List<TEvent> GetEventsByUserAndPrimaryEntities(int userId, HashSet<int> primaryEntityIds)
    {
        return _eventContext.Events
            .Where(e => e.LearnerId == userId && primaryEntityIds.Contains(e.KnowledgeComponentId))
            .Select(e => _eventSerializer.Deserialize(e.DomainEvent))
            .ToList();
    }
}