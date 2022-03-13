﻿using Microsoft.EntityFrameworkCore;
using Tutor.Infrastructure.Serialization;

namespace Tutor.Infrastructure.Database.EventStore.PostgreSqlEventStore
{
    public class EventContext : DbContext
    {
        internal DbSet<StoredDomainEvent> Events { get; set; }

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoredDomainEvent>().Property(e => e.DomainEvent).HasColumnType("jsonb");
            modelBuilder.Entity<StoredDomainEvent>().Property(e => e.DomainEvent).HasConversion(
            v => EventSerializer.Serialize(v),
            v => EventSerializer.Deserialize(v));
        }
    }
}