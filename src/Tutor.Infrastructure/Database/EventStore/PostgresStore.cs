using System.Linq;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Infrastructure.Database.BuildingBlocks;

namespace Tutor.Infrastructure.Database.EventStore
{
    public class PostgresStore : IEventStore
    {
        private readonly EventContext _eventContext;

        public PostgresStore(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        public async Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize)
        {
            page = page == 0 ? 1 : page;
            pageSize = pageSize > 1000 || pageSize < 0 ? 10 : pageSize;
            // Move to EventsRequest constructor?
            var storedEvents = await _eventContext.Events
                .GetPaged(page, pageSize);

            return new PagedResult<DomainEvent>(
                storedEvents.Results.Select(e => e.DomainEvent).ToList(),
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
                    TimeStamp = e.TimeStamp,
                    DomainEvent = e
                });
            _eventContext.Events.AddRange(eventsToSave);
            _eventContext.SaveChanges();
            aggregate.ClearChanges();
        }
    }
}
