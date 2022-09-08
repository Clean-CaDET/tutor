using System;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public class EventStoreOptions
    {
        public IEventSerializerProvider EventSerializerProvider { get; set; }
        public IEventStoreProvider EventStoreProvider { get; set; }

        public IEventStore GetEventStore()
        {
            Validate();
            try
            {
                return EventStoreProvider.GetEventStore(EventSerializerProvider.GetEventSerializer());
            }
            catch (Exception e)
            {
                throw new EventStoreConfigurationException("Invalid event store configuration.", e);
            }
        }

        public void Validate()
        {
            bool invalid = false;
            string message = string.Empty;
            if (EventSerializerProvider == null)
            {
                invalid = true;
                message = message + "Event serializer must be configured. ";
            }
            if (EventStoreProvider == null)
            {
                invalid = true;
                message = message + "Event store provider must be configured. ";
            }
            if (invalid)
                throw new EventStoreConfigurationException(message);
        }
    }
}
