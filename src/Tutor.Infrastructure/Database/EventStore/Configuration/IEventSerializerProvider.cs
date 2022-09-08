using Microsoft.Extensions.DependencyInjection;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public interface IEventSerializerProvider
    {
        public IEventSerializer GetEventSerializer();
        public void ConfigureServices(IServiceCollection services);
    }
}
