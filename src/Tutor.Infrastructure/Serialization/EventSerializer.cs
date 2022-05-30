using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Infrastructure.Serialization
{
    public class EventSerializer : IEventSerializer
    {
        public JsonDocument Serialize(DomainEvent @event)
        {
            return JsonSerializer.SerializeToDocument(@event, EventSerializationConfiguration.GetEventSerializerOptions());
        }

        public DomainEvent Deserialize(JsonDocument @event)
        {
            return JsonSerializer.Deserialize<DomainEvent>(@event, EventSerializationConfiguration.GetEventSerializerOptions());
        }
    }
}
