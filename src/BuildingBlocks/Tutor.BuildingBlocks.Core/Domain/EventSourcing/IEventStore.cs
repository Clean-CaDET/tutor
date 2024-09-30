using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.BuildingBlocks.Core.Domain.EventSourcing;

public interface IEventStore<TEvent> where TEvent : DomainEvent
{
    void Save(EventSourcedAggregateRoot aggregate);
    IEventQueryable<TEvent> Events { get; }
    // Hacky solution for performance gains for monitoring use cases
    List<TEvent> GetEventsByUserAndPrimaryEntities(int userId, HashSet<int> primaryEntityIds);
}
