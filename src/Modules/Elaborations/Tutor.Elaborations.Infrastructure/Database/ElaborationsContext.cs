using Microsoft.EntityFrameworkCore;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Database;

public class ElaborationsContext : DbContext
{
    public DbSet<ConceptElaborationTask> ConceptElaborationTasks { get; set; }
    public DbSet<ConceptRecord> ConceptRecords { get; set; }
    public DbSet<ConversationAttempt> ConversationAttempts { get; set; }
    public DbSet<ConversationRound> ConversationRounds { get; set; }
    public DbSet<RoundEvaluation> RoundEvaluations { get; set; }

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
            .HasMany(ca => ca.Rounds)
            .WithOne()
            .HasForeignKey(r => r.ConversationAttemptId);

        modelBuilder.Entity<ConversationAttempt>()
            .Navigation(ca => ca.Rounds)
            .HasField("_rounds");

        modelBuilder.Entity<ConversationAttempt>()
            .HasIndex(ca => new { ca.ConceptElaborationTaskId, ca.LearnerId });

        modelBuilder.Entity<ConversationRound>()
            .HasOne(r => r.Evaluation)
            .WithOne()
            .HasForeignKey<RoundEvaluation>(te => te.ConversationRoundId);

        modelBuilder.Entity<ConversationRound>()
            .HasIndex(r => new { r.ConversationAttemptId, r.Order });

        modelBuilder.Entity<ConversationRound>()
            .Property(r => r.Probes).HasColumnType("jsonb");

        modelBuilder.Entity<RoundEvaluation>(entity =>
        {
            entity.Property(te => te.Assessments).HasColumnType("jsonb");
            entity.Property(te => te.TriggeredMisconceptions).HasColumnType("jsonb");
        });
    }
}
