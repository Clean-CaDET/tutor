using Microsoft.EntityFrameworkCore;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Database;

public class ElaborationsContext : DbContext
{
    public DbSet<ConceptElaborationTask> ConceptElaborationTasks { get; set; }
    public DbSet<ConceptRecord> ConceptRecords { get; set; }
    public DbSet<ConversationAttempt> ConversationAttempts { get; set; }
    public DbSet<ConversationTurn> ConversationTurns { get; set; }
    public DbSet<TurnEvaluation> TurnEvaluations { get; set; }

    public ElaborationsContext(DbContextOptions<ElaborationsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("elaborations");

        ConfigureConceptElaborationTasks(modelBuilder);
        ConfigureConceptRecords(modelBuilder);
        ConfigureConversations(modelBuilder);
    }

    private static void ConfigureConceptElaborationTasks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConceptElaborationTask>(entity =>
        {
            entity.HasIndex(cet => new { cet.UnitId, cet.Order });
            entity.HasOne(cet => cet.ConceptRecord)
                .WithOne()
                .HasForeignKey<ConceptRecord>(r => r.ConceptElaborationTaskId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureConceptRecords(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConceptRecord>(entity =>
        {
            entity.Property(r => r.KeyPropositions).HasColumnType("jsonb");
            entity.Property(r => r.CommonMisconceptions).HasColumnType("jsonb");
            entity.Property(r => r.KeyRelations).HasColumnType("jsonb");
        });
    }

    private static void ConfigureConversations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConversationAttempt>()
            .HasMany(ca => ca.Turns)
            .WithOne()
            .HasForeignKey(ct => ct.ConversationAttemptId);

        modelBuilder.Entity<ConversationAttempt>()
            .Navigation(ca => ca.Turns)
            .HasField("_turns");

        modelBuilder.Entity<ConversationAttempt>()
            .HasIndex(ca => new { ca.ConceptElaborationTaskId, ca.LearnerId });

        modelBuilder.Entity<ConversationTurn>()
            .HasOne(ct => ct.Evaluation)
            .WithOne()
            .HasForeignKey<TurnEvaluation>(te => te.ConversationTurnId);

        modelBuilder.Entity<ConversationTurn>()
            .OwnsOne(ct => ct.Probe, probe => probe.ToJson());

        modelBuilder.Entity<ConversationTurn>()
            .HasIndex(ct => new { ct.ConversationAttemptId, ct.Order });

        modelBuilder.Entity<TurnEvaluation>(entity =>
        {
            entity.Property(te => te.Assessments).HasColumnType("jsonb");
            entity.Property(te => te.MisconceptionsTriggeredKeys).HasColumnType("jsonb");
        });
    }
}
