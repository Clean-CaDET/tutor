using Dahomey.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore.DefaultEventSerializer
{
    public class DefaultEventSerializer : IEventSerializer
    {
        private JsonSerializerOptions _options;

        public DefaultEventSerializer(IDictionary<Type, string> eventRelatedTypes, string discriminatorMemberName)
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

        public DefaultEventSerializer(IDictionary<Type, string> eventRelatedTypes) : this(eventRelatedTypes, "$discriminator") { }

        public DomainEvent Deserialize(JsonDocument @event)
        {
            return JsonSerializer.Deserialize<DomainEvent>(@event, _options);
        }

        public JsonDocument Serialize(DomainEvent @event)
        {
            return JsonSerializer.SerializeToDocument(@event, _options);
        }
    }
}
