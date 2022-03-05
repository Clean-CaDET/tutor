using Microsoft.EntityFrameworkCore;
using Tutor.Infrastructure.Serialization;

namespace Tutor.Infrastructure.Database.EventStore.PostgreSqlEventStore
{
    public class EventContext : DbContext
    {
        internal DbSet<EventWrapper> Events { get; set; }

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventWrapper>().Property(e => e.DomainEvent).HasColumnType("jsonb");
            modelBuilder.Entity<EventWrapper>().Property(e => e.DomainEvent).HasConversion(
            v => EventSerializer.Serialize(v),
            v => EventSerializer.Deserialize(v));
            modelBuilder.Entity<EventWrapper>().HasIndex(e => e.Timestamp);
        }
    }
}
