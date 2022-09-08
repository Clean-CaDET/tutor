using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore
{
    public interface IEventStore
    {
        void Save(EventSourcedAggregateRoot aggregate);
        IEventQueryable Events { get; }
        Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
        void EnsureCreated();
        void EnsureDeleted();
        void ExecuteRaw(string query);
    }
}
