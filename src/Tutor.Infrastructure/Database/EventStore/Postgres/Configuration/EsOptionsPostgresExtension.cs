using Tutor.Infrastructure.Database.EventStore.Configuration;

namespace Tutor.Infrastructure.Database.EventStore.Postgres.Configuration
{
    public static class EsOptionsPostgresExtension
    {
        public static EventStoreOptions UsePostgres(this EventStoreOptions options, string connectionString)
        {
            options.EventStoreProvider = new PostgresStoreProvider(connectionString);
            return options;
        }
    }
}
