using Dahomey.Json;
using System.Collections.Immutable;
using System.Text.Json;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.EventSourcing;

namespace Tutor.BuildingBlocks.Infrastructure.Database.EventStore.DefaultEventSerializer;

public class DefaultEventSerializer<TEvent> : IEventSerializer<TEvent> where TEvent : DomainEvent
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

    public JsonDocument Serialize(TEvent @event)
    {
        return JsonSerializer.SerializeToDocument(@event, _options);
    }

    public TEvent Deserialize(JsonDocument @event)
    {
        return @event.Deserialize<TEvent>(_options)!;
    }
}