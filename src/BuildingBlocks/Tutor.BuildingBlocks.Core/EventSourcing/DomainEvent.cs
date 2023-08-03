namespace Tutor.BuildingBlocks.Core.EventSourcing;

public abstract class DomainEvent
{
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
}