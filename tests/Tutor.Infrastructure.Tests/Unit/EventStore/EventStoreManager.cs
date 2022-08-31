using Microsoft.EntityFrameworkCore;
using System;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Infrastructure.Database.EventStore.Postgres;
using Tutor.Infrastructure.Tests.TestData.EventStore;

namespace Tutor.Infrastructure.Tests.Unit.EventStore
{
    public class EventStoreManager : IDisposable
    {
        private readonly string _connectionString = $"Server=localhost;Port=5432;Database=event-store-test;User ID=postgres;Password=super;Integrated Security=false;Pooling=true;";
        private EventContext _eventContext;

        public IEventStore EventStore { get; private set; }

        public EventStoreManager()
        {
            var options = new DbContextOptionsBuilder<EventContext>().UseNpgsql(_connectionString).Options;
            _eventContext = new EventContext(options);
            _eventContext.Database.EnsureCreated();
            EventStore = new PostgresStore(_eventContext, new TestEventSerializer());

            var eventSeeder = new TestAggregate();
            eventSeeder.SeedEvents(QueryTestData._allEvents);
            EventStore.Save(eventSeeder);
        }

        public void Dispose()
        {
            _eventContext.Database.EnsureDeleted();
        }
    }
}
