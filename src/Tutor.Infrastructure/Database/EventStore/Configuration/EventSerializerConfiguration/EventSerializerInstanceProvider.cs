using Microsoft.Extensions.DependencyInjection;

namespace Tutor.Infrastructure.Database.EventStore.Configuration.EventSerializerConfiguration
{
    public class EventSerializerInstanceProvider : IEventSerializerProvider
    {
        private readonly IEventSerializer _eventSerializer;

        public EventSerializerInstanceProvider(IEventSerializer eventSerializer)
        {
            _eventSerializer = eventSerializer;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEventSerializer>(_eventSerializer);
        }

        public IEventSerializer GetEventSerializer()
        {
            return _eventSerializer;
        }
    }
}
