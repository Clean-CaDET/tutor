using Microsoft.Extensions.DependencyInjection;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public interface IEventStoreProvider
    {
        IEventStore GetEventStore(IEventSerializer serializer);
        void Configure(IServiceCollection services);
        void Unconfigure(IServiceCollection services);
    }
}
