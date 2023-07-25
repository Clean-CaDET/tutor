using System.Collections.Immutable;
using System.Text.Json;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.DefaultEventSerializer;

public class DefaultEventSerializer : IEventSerializer
{
    private readonly JsonSerializerOptions _options;

    public DefaultEventSerializer(IImmutableDictionary<Type, string> eventRelatedTypes, string discriminatorMemberName)
    {
        _options = new JsonSerializerOptions();
        _options.SetupExtensions();
        var registry = _options.GetDiscriminatorConventionRegistry();
        registry.ClearConventions();
        registry.RegisterConvention(new AllowedTypesDiscriminatorConvention<string>(_options, eventRelatedTypes, discriminatorMemberName));
        foreach (var type in eventRelatedTypes.Keys)
        {
            registry.RegisterType(type);
        }
    }

    public DefaultEventSerializer(IImmutableDictionary<Type, string> eventRelatedTypes) : this(eventRelatedTypes, "$discriminator") { }

    public DomainEvent Deserialize(JsonDocument @event)
    {
        return @event.Deserialize<DomainEvent>(_options);
    }

    public JsonDocument Serialize(DomainEvent @event)
    {
        return JsonSerializer.SerializeToDocument(@event, _options);
    }
}