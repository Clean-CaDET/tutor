using Microsoft.Extensions.DependencyInjection;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public class EventSerializerInstanceProvider : IEventSerializerProvider
    {
        private readonly IEventSerializer _eventSerializer;

        public EventSerializerInstanceProvider(IEventSerializer eventSerializer)
        {
            _eventSerializer = eventSerializer;
        }

        public IEventSerializer GetEventSerializer()
        {
            return _eventSerializer;
        }

        public void Configure(IServiceCollection services)
        {
            services.AddSingleton(_eventSerializer);
        }

        public void Unconfigure(IServiceCollection services)
        {
            services.RemoveService<IEventSerializer>();
        }
    }
}
