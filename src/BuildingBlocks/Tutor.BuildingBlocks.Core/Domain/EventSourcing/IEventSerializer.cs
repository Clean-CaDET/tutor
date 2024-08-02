using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.BuildingBlocks.Core.Domain.EventSourcing;

public interface IEventSerializer<TEvent> where TEvent : DomainEvent
{
    JsonDocument Serialize(TEvent @event);
    TEvent Deserialize(JsonDocument @event);
}
