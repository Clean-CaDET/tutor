using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutor.Infrastructure.Database.EventStore.PostgreSQLEventStore
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
            modelBuilder.Entity<EventWrapper>().HasIndex(e => e.Timestamp);
        }
    }
}
