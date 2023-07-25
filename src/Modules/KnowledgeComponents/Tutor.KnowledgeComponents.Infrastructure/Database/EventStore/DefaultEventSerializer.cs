using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore;

public class DefaultEventSerializer : IEventSerializer
{
    private readonly JsonSerializerOptions _options = new()
    {
        TypeInfoResolver = new EventSerializationConfiguration()
    };

    public DomainEvent Deserialize(JsonDocument @event)
    {
        return @event.Deserialize<DomainEvent>(_options);
    }

    public JsonDocument Serialize(DomainEvent @event)
    {
        return JsonSerializer.SerializeToDocument(@event, _options);
    }
}