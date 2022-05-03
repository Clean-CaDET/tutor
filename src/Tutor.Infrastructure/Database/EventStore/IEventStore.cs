using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Infrastructure.Database.BuildingBlocks;

namespace Tutor.Infrastructure.Database.EventStore
{
    public interface IEventStore
    {
        void Save(EventSourcedAggregateRoot aggregate);
        Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
    }
}
