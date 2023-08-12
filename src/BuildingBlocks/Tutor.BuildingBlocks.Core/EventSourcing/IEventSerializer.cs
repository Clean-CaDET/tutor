using System.Text.Json;

namespace Tutor.BuildingBlocks.Core.EventSourcing;

public interface IEventSerializer
{
    JsonDocument Serialize(DomainEvent @event);
    DomainEvent Deserialize(JsonDocument @event);
}