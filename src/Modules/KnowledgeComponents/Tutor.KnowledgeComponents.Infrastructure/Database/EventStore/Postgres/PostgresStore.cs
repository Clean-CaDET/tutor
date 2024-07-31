using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.Postgres;

public class PostgresStore<TEvent> : IEventStore<TEvent> where TEvent : DomainEvent
{
    private readonly KnowledgeComponentsContext _eventContext;
    private readonly IEventSerializer<TEvent> _eventSerializer;

    public IEventQueryable<TEvent> Events => new PostgresEventQueryable<TEvent>(_eventContext.Events, _eventSerializer);

    public PostgresStore(KnowledgeComponentsContext eventContext, IEventSerializer<TEvent> eventSerializer)
    {
        _eventContext = eventContext;
        _eventSerializer = eventSerializer;
    }

    public async Task<PagedResult<TEvent>> GetEventsAsync(int page, int pageSize)
    {
        var storedEvents = await _eventContext.Events
            .GetPaged(page, pageSize);

        return new PagedResult<TEvent>(
            storedEvents.Results.Select(e => _eventSerializer.Deserialize(e.DomainEvent)).ToList(),
            storedEvents.TotalCount);
    }

    public void Save(EventSourcedAggregateRoot aggregate)
    {
        // class name is temporarily used as aggregate type until we choose a better approach
        var aggregateType = aggregate.GetType().Name;

        var eventsToSave = aggregate.GetChanges().Select(
            e => new StoredDomainEvent()
            {
                AggregateType = aggregateType,
                AggregateId = aggregate.Id,
                TimeStamp = e.TimeStamp.ToUniversalTime(),
                DomainEvent = _eventSerializer.Serialize((TEvent)e)
            });
        _eventContext.Events.AddRange(eventsToSave);
        aggregate.ClearChanges();
    }
}