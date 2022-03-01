using System;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public abstract class DomainEvent
    {
        public int AggregateId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
