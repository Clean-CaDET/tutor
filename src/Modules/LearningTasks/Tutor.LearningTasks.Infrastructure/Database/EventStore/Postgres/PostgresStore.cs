using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;

namespace Tutor.LearningTasks.Infrastructure.Database.EventStore.Postgres;

public class PostgresStore<TEvent> : IEventStore<TEvent> where TEvent : DomainEvent
{
    private readonly LearningTasksContext _eventContext;
    private readonly IEventSerializer<TEvent> _eventSerializer;

    public PostgresStore(LearningTasksContext eventContext, IEventSerializer<TEvent> eventSerializer)
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
            e => new StoredTaskDomainEvent()
            {
                AggregateType = aggregateType,
                AggregateId = aggregate.Id,
                TimeStamp = e.TimeStamp.ToUniversalTime(),
                DomainEvent = _eventSerializer.Serialize((TEvent)e)
            });
        _eventContext.Events.AddRange(eventsToSave);
        aggregate.ClearChanges();
    }

    public List<TEvent> GetEventsByUserAndPrimaryEntities(int userId, HashSet<int> primaryEntityIds)
    {
        return _eventContext.Events
            .Where(e => e.LearnerId == userId && primaryEntityIds.Contains(e.TaskId))
            .Select(e => _eventSerializer.Deserialize(e.DomainEvent))
            .ToList();
    }
}