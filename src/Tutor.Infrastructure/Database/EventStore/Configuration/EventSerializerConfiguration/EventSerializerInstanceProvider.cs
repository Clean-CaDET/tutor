using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Tutor.Infrastructure.Database.EventStore.Configuration.EventSerializerConfiguration
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
