using Dahomey.Json;
using Dahomey.Json.Serialization.Conventions;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.EventStore
{
    public static class EventSerializer
    {
        public static JsonSerializerOptions GetSerializerOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.SetupExtensions();
            DiscriminatorConventionRegistry registry = options.GetDiscriminatorConventionRegistry();
            registry.ClearConventions();
            registry.RegisterConvention(new DefaultDiscriminatorConvention<string>(options, "type"));

            registry.RegisterType<AssessmentEventAnswered>();

            return options;
        }

        public static string Serialize(DomainEvent @event)
        {
            return JsonSerializer.Serialize(@event, GetSerializerOptions());
        }

        public static DomainEvent Deserialize(string @event)
        {
            return JsonSerializer.Deserialize<DomainEvent>(@event, GetSerializerOptions());
        }
    }
}
