﻿using Microsoft.EntityFrameworkCore;
using System;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Infrastructure.Database.EventStore.DefaultEventSerializer;
using Tutor.Infrastructure.Database.EventStore.Postgres;
using static Tutor.Infrastructure.Tests.TestData.EventStore.TestEvents;

namespace Tutor.Infrastructure.Tests.Integration.EventStore
{
    public class EventStoreManager : IDisposable
    {
        private const string ConnectionString = "Server=localhost;Port=5432;Database=event-store-test;User ID=postgres;Password=super;Integrated Security=false;Pooling=true;";
        private readonly EventContext _eventContext;

        public IEventStore EventStore { get; }

        public EventStoreManager()
        {
            var options = new DbContextOptionsBuilder<EventContext>().UseNpgsql(ConnectionString).Options;
            _eventContext = new EventContext(options);
            _eventContext.Database.EnsureCreated();
            EventStore = new PostgresStore(_eventContext, new DefaultEventSerializer(Types));

            var eventSeeder = new TestAggregate();
            eventSeeder.SeedEvents(Examples);
            EventStore.Save(eventSeeder);
        }

        public void Dispose()
        {
            _eventContext.Database.EnsureDeleted();
        }
    }
}
