using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Tutor.Infrastructure.Database.EventStore.Configuration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddEventStore(this IServiceCollection services, Action<EventStoreOptions> optionsAction)
        {
            EventStoreOptions options = new EventStoreOptions();
            optionsAction(options);
            options.Validate();
            services.Add(new ServiceDescriptor(typeof(IEventStore), _ => options.GetEventStore(), ServiceLifetime.Scoped));
            return services;
        }

        public static IServiceCollection RemoveEventStore(this IServiceCollection services)
        {
            var eventStoreDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IEventStore));
            services.Remove(eventStoreDescriptor);
            return services;
        }
    }
}
