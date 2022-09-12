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
            services.AddSingleton(options);
            options.Configure(services);
            return services;
        }

        public static IServiceCollection RemoveEventStore(this IServiceCollection services)
        {
            var optionsDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(EventStoreOptions), null);
            if (optionsDescriptor != null && optionsDescriptor.ImplementationInstance != null)
            {
                var options = optionsDescriptor.ImplementationInstance as EventStoreOptions;
                options.Unconfigure(services);
                services.Remove(optionsDescriptor);
            }
            return services;
        }

        internal static IServiceCollection RemoveService<T>(this IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(T));
            services.Remove(descriptor);
            return services;
        }
    }
}
