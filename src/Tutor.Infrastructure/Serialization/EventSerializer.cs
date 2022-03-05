using Dahomey.Json;
using Dahomey.Json.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Infrastructure.Serialization
{
    public static class EventSerializer
    {
        private static readonly IDictionary<Type, string> eventRelatedTypes = new Dictionary<Type, string>()
        {
            { typeof(AssessmentEventAnswered), "AssessmentEventAnswered"}
        };

        public static JsonSerializerOptions SetupEvents(this JsonSerializerOptions options)
        {
            DiscriminatorConventionRegistry registry = options.GetDiscriminatorConventionRegistry();
            registry.RegisterConvention(new CustomDiscriminatorConvention<string>(options, eventRelatedTypes, "type"));

            foreach (Type type in eventRelatedTypes.Keys)
            {
                registry.RegisterType(type);
            }

            return options;
        }

        public static JsonSerializerOptions GetEventSerializerOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.SetupExtensions();
            options.GetDiscriminatorConventionRegistry().ClearConventions();
            options.SetupEvents();

            return options;
        }

        public static string Serialize(DomainEvent @event)
        {
            return JsonSerializer.Serialize(@event, GetEventSerializerOptions());
        }

        public static DomainEvent Deserialize(string @event)
        {
            return JsonSerializer.Deserialize<DomainEvent>(@event, GetEventSerializerOptions());
        }
    }
}
