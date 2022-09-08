using System;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Infrastructure.Database.EventStore.Configuration;
using Tutor.Infrastructure.Database.EventStore.Configuration.EventSerializerConfiguration;
using Tutor.Infrastructure.Database.EventStore.Postgres.Configuration;
using static Tutor.Infrastructure.Tests.TestData.EventStore.TestEvents;

namespace Tutor.Infrastructure.Tests.Integration.EventStore
{
    public class EventStoreManager : IDisposable
    {
        private readonly string _connectionString = $"Server=localhost;Port=5432;Database=event-store-test;User ID=postgres;Password=super;Integrated Security=false;Pooling=true;";
        private EventStoreOptions _options;

        public EventStoreManager()
        {
            _options = new EventStoreOptions().UsePostgres(_connectionString).UseDefaultSerializer(Types);

            var eventStore = GetEventStore();
            eventStore.EnsureCreated();
            var eventSeeder = new TestAggregate();
            eventSeeder.SeedEvents(Examples);
            eventStore.Save(eventSeeder);
        }

        public IEventStore GetEventStore()
        {
            return _options.GetEventStore();
        }

        public IEventQueryable GetEventQueryable()
        {
            return _options.GetEventStore().Events;
        }

        public void Dispose()
        {
            GetEventStore().EnsureDeleted();
        }
    }
}
