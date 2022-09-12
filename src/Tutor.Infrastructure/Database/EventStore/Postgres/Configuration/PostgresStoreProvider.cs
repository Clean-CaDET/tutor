using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.Infrastructure.Database.EventStore.Configuration;

namespace Tutor.Infrastructure.Database.EventStore.Postgres.Configuration
{
    internal class PostgresStoreProvider : IEventStoreProvider
    {
        private readonly string _connectionString;

        public PostgresStoreProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEventStore GetEventStore(IEventSerializer serializer)
        {
            var options = new DbContextOptionsBuilder<EventContext>().UseNpgsql(_connectionString).Options;
            var context = new EventContext(options);
            return new PostgresStore(context, serializer);
        }

        public void Configure(IServiceCollection services)
        {
            services.AddDbContext<EventContext>(options => options.UseNpgsql(_connectionString));
            services.AddScoped<IEventStore, PostgresStore>();
        }

        public void Unconfigure(IServiceCollection services)
        {
            services.RemoveService<IEventStore>();
            services.RemoveService<DbContextOptions<EventContext>>();
        }
    }
}
