using System.Text.Json;

namespace Tutor.Core.BuildingBlocks.EventSourcing;

public interface IEventSerializer
{
    JsonDocument Serialize(DomainEvent @event);
    DomainEvent Deserialize(JsonDocument @event);
}