using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore
{
    public interface IEventStore
    {
        void Save(EventSourcedAggregateRoot aggregate);
        IEnumerable<DomainEvent> GetEvents(DateTime? start, DateTime? end);
        IEnumerable<DomainEvent> GetEventsByAggregate(int aggregateId, DateTime? start, DateTime? end);
    }
}
