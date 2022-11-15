using System.Threading.Tasks;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public interface IEventStore
    {
        void Save(EventSourcedAggregateRoot aggregate);
        IEventQueryable Events { get; }
        Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
    }
}
