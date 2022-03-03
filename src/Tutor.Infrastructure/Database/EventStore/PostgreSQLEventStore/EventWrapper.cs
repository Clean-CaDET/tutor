using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore.PostgreSqlEventStore
{
    internal class EventWrapper
    {
        public int Id { get; set; }
        public int AggregateId { get; set; }
        public DateTime Timestamp { get; set; }
        public DomainEvent DomainEvent { get; set; }

        public EventWrapper() { }

        public EventWrapper(DomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
            AggregateId = domainEvent.AggregateId;
            Timestamp = domainEvent.Timestamp;
        }
    }
}
