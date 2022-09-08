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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EventContext>(opt =>
                opt.UseNpgsql(_connectionString));
            services.AddScoped<IEventStore, PostgresStore>();
        }

        public IEventStore GetEventStore(IEventSerializer serializer)
        {
            var options = new DbContextOptionsBuilder<EventContext>().UseNpgsql(_connectionString).Options;
            var context = new EventContext(options);
            context.Database.EnsureCreated();
            return new PostgresStore(context, serializer);
        }
    }
}
