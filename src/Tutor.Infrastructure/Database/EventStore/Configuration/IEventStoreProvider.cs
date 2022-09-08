using Microsoft.Extensions.DependencyInjection;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public interface IEventStoreProvider
    {
        public IEventStore GetEventStore(IEventSerializer serializer);
        public void ConfigureServices(IServiceCollection services);
    }
}
