using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.KnowledgeComponents.Core.Domain.EventSourcing;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.Postgres;

public class PostgresStore : IKnowledgeComponentEventStore
{
    private readonly KnowledgeComponentsContext _eventContext;
    private readonly IKnowledgeComponentEventSerializer _eventSerializer;

    public IKnowledgeComponentEventQueryable Events => new PostgresEventQueryable(_eventContext.Events, _eventSerializer);

    public PostgresStore(KnowledgeComponentsContext eventContext, IKnowledgeComponentEventSerializer eventSerializer)
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