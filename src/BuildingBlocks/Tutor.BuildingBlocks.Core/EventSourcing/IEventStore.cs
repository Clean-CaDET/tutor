using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.BuildingBlocks.Core.EventSourcing;

public interface IEventStore
{
    void Save(EventSourcedAggregateRoot aggregate);
    IEventQueryable Events { get; }
    Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
}