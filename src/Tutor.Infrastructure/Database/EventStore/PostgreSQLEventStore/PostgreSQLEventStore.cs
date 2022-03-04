using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore.PostgreSqlEventStore
{
    public class PostgreSqlEventStore : IEventStore
    {
        private readonly EventContext _eventContext;

        public PostgreSqlEventStore(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        public IEnumerable<DomainEvent> GetEvents(DateTime? start, DateTime? end)
        {
            DateTime min = start ?? DateTime.MinValue;
            DateTime max = end ?? DateTime.MaxValue;
            return _eventContext.Events.Where(e => e.Timestamp > min && e.Timestamp < max).Select(e => e.DomainEvent).ToList();
        }

        public IEnumerable<DomainEvent> GetEventsByAggregate(int aggregateId, DateTime? start, DateTime? end)
        {
            DateTime min = start ?? DateTime.MinValue;
            DateTime max = end ?? DateTime.MaxValue;
            return _eventContext.Events.Where(
                e => e.AggregateId == aggregateId && e.Timestamp > min && e.Timestamp < max).Select(e => e.DomainEvent).ToList();
        }

        public void Save(EventSourcedAggregateRoot aggregate)
        {
            IEnumerable<EventWrapper> eventsToSave =
                aggregate.GetChanges().Select(e => new EventWrapper(e));
            _eventContext.Events.AddRange(eventsToSave);
            _eventContext.SaveChanges();
            aggregate.ClearChanges();
        }
    }
}
