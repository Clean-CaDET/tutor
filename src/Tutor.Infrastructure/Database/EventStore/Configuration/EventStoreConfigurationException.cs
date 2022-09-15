using System;
using System.Runtime.Serialization;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    [Serializable]
    public class EventStoreConfigurationException : Exception
    {
        public EventStoreConfigurationException()
        {
        }

        public EventStoreConfigurationException(string message) : base(message)
        {
        }

        public EventStoreConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EventStoreConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
