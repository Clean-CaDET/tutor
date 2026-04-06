using Microsoft.EntityFrameworkCore;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.Domain.ElaborationTasks;

namespace Tutor.Elaborations.Infrastructure.Database;

public class ElaborationsContext : DbContext
{
    public DbSet<ConceptRecord> ConceptRecords { get; set; }
    public DbSet<KeyProposition> KeyPropositions { get; set; }
    public DbSet<BoundaryCondition> BoundaryConditions { get; set; }
    public DbSet<CommonMisconception> CommonMisconceptions { get; set; }
    public DbSet<KeyRelation> KeyRelations { get; set; }
    public DbSet<ElaborationTask> ElaborationTasks { get; set; }
    public DbSet<ConversationAttempt> ConversationAttempts { get; set; }
    public DbSet<ConversationTurn> ConversationTurns { get; set; }
    public DbSet<TurnEvaluation> TurnEvaluations { get; set; }

    public ElaborationsContext(DbContextOptions<ElaborationsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("elaborations");

        ConfigureConceptRecords(modelBuilder);
        ConfigureElaborationTasks(modelBuilder);
        ConfigureConversations(modelBuilder);
    }

    private static void ConfigureConceptRecords(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConceptRecord>()
            .HasMany(cr => cr.KeyPropositions)
            .WithOne()
            .HasForeignKey(kp => kp.ConceptRecordId);

        modelBuilder.Entity<ConceptRecord>()
            .HasMany(cr => cr.BoundaryConditions)
            .WithOne()
            .HasForeignKey(bc => bc.ConceptRecordId);

        modelBuilder.Entity<ConceptRecord>()
            .HasMany(cr => cr.CommonMisconceptions)
            .WithOne()
            .HasForeignKey(cm => cm.ConceptRecordId);

        modelBuilder.Entity<ConceptRecord>()
            .HasMany(cr => cr.KeyRelations)
            .WithOne()
            .HasForeignKey(kr => kr.ConceptRecordId);
    }

    private static void ConfigureElaborationTasks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ElaborationTask>()
            .HasOne<ConceptRecord>()
            .WithMany()
            .HasForeignKey(et => et.ConceptRecordId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ElaborationTask>()
            .HasIndex(et => new { et.UnitId, et.Order });
    }

    private static void ConfigureConversations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConversationAttempt>()
            .HasMany(ca => ca.Turns)
            .WithOne()
            .HasForeignKey(ct => ct.ConversationAttemptId);

        modelBuilder.Entity<ConversationAttempt>()
            .HasIndex(ca => new { ca.ElaborationTaskId, ca.LearnerId });

        modelBuilder.Entity<ConversationTurn>()
            .HasOne(ct => ct.Evaluation)
            .WithOne()
            .HasForeignKey<TurnEvaluation>(te => te.ConversationTurnId);

        modelBuilder.Entity<ConversationTurn>()
            .HasIndex(ct => new { ct.ConversationAttemptId, ct.Order });

        modelBuilder.Entity<TurnEvaluation>(entity =>
        {
            entity.Property(te => te.PropositionsCoveredIds)
                .HasColumnType("jsonb");
            entity.Property(te => te.MisconceptionsTriggeredIds)
                .HasColumnType("jsonb");
            entity.Property(te => te.RelationsArticulatedIds)
                .HasColumnType("jsonb");
        });
    }
}
