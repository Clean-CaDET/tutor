using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore
{
    public interface IEventStore
    {
        void Save(EventSourcedAggregateRoot aggregate);
        IEnumerable<DomainEvent> GetEvents(DateTime? start, DateTime? end);
    }
}
