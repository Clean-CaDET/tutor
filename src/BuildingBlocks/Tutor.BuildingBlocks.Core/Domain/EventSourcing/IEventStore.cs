using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.BuildingBlocks.Core.Domain.EventSourcing;

public interface IEventStore<TEvent> where TEvent : DomainEvent
{
    void Save(EventSourcedAggregateRoot aggregate);
    IEventQueryable<TEvent> Events { get; }
    Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
}
