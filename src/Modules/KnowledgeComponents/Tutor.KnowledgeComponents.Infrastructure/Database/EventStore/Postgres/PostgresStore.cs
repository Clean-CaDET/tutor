using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.Postgres;

public class PostgresStore : IEventStore
{
    private readonly KnowledgeComponentsContext _eventContext;
    private readonly IEventSerializer _eventSerializer;

    public IEventQueryable Events => new PostgresEventQueryable(_eventContext.Events, _eventSerializer);

    public PostgresStore(KnowledgeComponentsContext eventContext, IEventSerializer eventSerializer)
    {
        _eventContext = eventContext;
        _eventSerializer = eventSerializer;
    }

    public async Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize)
    {
        var storedEvents = await _eventContext.Events
            .GetPaged(page, pageSize);

        return new PagedResult<DomainEvent>(
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
                DomainEvent = _eventSerializer.Serialize(e)
            });
        _eventContext.Events.AddRange(eventsToSave);
        aggregate.ClearChanges();
    }
}