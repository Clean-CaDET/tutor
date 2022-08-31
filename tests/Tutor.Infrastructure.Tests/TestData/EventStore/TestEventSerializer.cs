using Dahomey.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Infrastructure.Serialization;

namespace Tutor.Infrastructure.Tests.TestData.EventStore
{
    public class TestEventSerializer : IEventSerializer
    {
        private static readonly IDictionary<Type, string> EventTypes = new Dictionary<Type, string>
        {
            { typeof(TestEventA), "TestEventA" },
            { typeof(TestEventB), "TestEventB" },
            { typeof(TestEventC), "TestEventC" }
        };

        private JsonSerializerOptions _options;

        public TestEventSerializer()
        {
            _options = new JsonSerializerOptions();
            _options.SetupExtensions();
            var registry = _options.GetDiscriminatorConventionRegistry();
            registry.ClearConventions();
            registry.RegisterConvention(new AllowedTypesDiscriminatorConvention<string>(_options, EventTypes, "$discriminator"));
            foreach (var type in EventTypes.Keys)
            {
                registry.RegisterType(type);
            }
        }

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
