using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore
{
    public interface IEventSerializer
    {
        JsonDocument Serialize(DomainEvent @event);
        DomainEvent Deserialize(JsonDocument @event);
    }
}
