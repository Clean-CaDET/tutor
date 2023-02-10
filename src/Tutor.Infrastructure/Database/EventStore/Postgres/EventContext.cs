using Microsoft.EntityFrameworkCore;

namespace Tutor.Infrastructure.Database.EventStore.Postgres;

public class EventContext : DbContext
{
    internal DbSet<StoredDomainEvent> Events { get; private set; }

    public EventContext(DbContextOptions<EventContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StoredDomainEvent>().Property(e => e.DomainEvent).HasColumnType("jsonb");
        modelBuilder.Entity<StoredDomainEvent>().HasIndex(e => e.TimeStamp);
    }
}