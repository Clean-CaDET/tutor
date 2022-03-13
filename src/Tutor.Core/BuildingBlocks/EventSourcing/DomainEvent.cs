using System;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public abstract class DomainEvent
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
