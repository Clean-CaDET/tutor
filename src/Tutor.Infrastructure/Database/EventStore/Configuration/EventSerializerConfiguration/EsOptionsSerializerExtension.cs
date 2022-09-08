using System;
using System.Collections.Immutable;

namespace Tutor.Infrastructure.Database.EventStore.Configuration.EventSerializerConfiguration
{
    public static class EsOptionsSerializerExtension
    {
        public static EventStoreOptions UseSerializer(this EventStoreOptions options, IEventSerializer eventSerializer)
        {
            if (eventSerializer == null)
                throw new EventStoreConfigurationException(
                    "Invalid event serializer configuration.",
                    new ArgumentNullException(nameof(eventSerializer)));
            options.EventSerializerProvider = new EventSerializerInstanceProvider(eventSerializer);
            return options;
        }

        public static EventStoreOptions UseDefaultSerializer(this EventStoreOptions options, IImmutableDictionary<Type, string> eventRelatedTypes)
        {
            if (eventRelatedTypes == null)
                throw new EventStoreConfigurationException(
                    "Invalid event serializer configuration.",
                    new ArgumentNullException(nameof(eventRelatedTypes)));
            var eventSerializer = new DefaultEventSerializer.DefaultEventSerializer(eventRelatedTypes);
            options.EventSerializerProvider = new EventSerializerInstanceProvider(eventSerializer);
            return options;
        }
    }
}
