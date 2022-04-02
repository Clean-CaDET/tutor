using System;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public abstract class DomainEvent
    {
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }
}
