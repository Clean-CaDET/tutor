using Microsoft.Extensions.DependencyInjection;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public interface IEventSerializerProvider
    {
        IEventSerializer GetEventSerializer();
        void Configure(IServiceCollection services);
        void Unconfigure(IServiceCollection services);
    }
}
