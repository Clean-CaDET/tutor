using Microsoft.EntityFrameworkCore;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;
using Tutor.Infrastructure.Serialization;

namespace Tutor.Infrastructure.Database.EventStore
{
    public class EventContext : DbContext
    {
        internal DbSet<StoredKcEvent> KcEvents { get; private set; }

        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoredKcEvent>().Property(e => e.KcEvent).HasColumnType("jsonb");
            modelBuilder.Entity<StoredKcEvent>().Property(e => e.KcEvent).HasConversion(
                v => EventSerializer.Serialize(v),
                v => (KnowledgeComponentEvent)EventSerializer.Deserialize(v));
            modelBuilder.Entity<StoredKcEvent>().HasIndex(e => e.TimeStamp);
            modelBuilder.Entity<StoredKcEvent>().HasIndex(e => e.LearnerId);
            modelBuilder.Entity<StoredKcEvent>().HasIndex(e => e.KnowledgeComponentId);
        }
    }
}
