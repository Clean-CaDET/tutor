using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore
{
    public class PostgreSqlStore : IEventStore
    {
        private readonly EventContext _eventContext;

        public PostgreSqlStore(EventContext eventContext)
        {
            _eventContext = eventContext;
        }

        public IEnumerable<DomainEvent> GetEvents(DateTime? start, DateTime? end)
        {
            DateTime min = start ?? DateTime.MinValue;
            DateTime max = end ?? DateTime.MaxValue;
            return _eventContext.Events.Where(
                e => e.DomainEvent.TimeStamp > min && e.DomainEvent.TimeStamp < max).Select(e => e.DomainEvent).ToList();
        }

        public void Save(EventSourcedAggregateRoot aggregate)
        {
            // class name is temporarily used as aggregate type until we choose a better approach
            string aggregateType = aggregate.GetType().Name;

            IEnumerable<StoredDomainEvent> eventsToSave = aggregate.GetChanges().Select(
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
