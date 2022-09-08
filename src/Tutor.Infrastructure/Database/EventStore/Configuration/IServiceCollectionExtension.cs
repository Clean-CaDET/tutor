using Microsoft.Extensions.DependencyInjection;
using System;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddEventStore(this IServiceCollection services, Action<EventStoreOptions> optionsAction)
        {
            EventStoreOptions options = new EventStoreOptions();
            optionsAction(options);
            options.ConfigureServices(services);
            return services;
        }
    }
}
