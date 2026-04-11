using Microsoft.EntityFrameworkCore;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Infrastructure.Database;

public class ElaborationsContext : DbContext
{
    public DbSet<ConceptElaborationTask> ConceptElaborationTasks { get; set; }
    public DbSet<KeyProposition> KeyPropositions { get; set; }
    public DbSet<BoundaryCondition> BoundaryConditions { get; set; }
    public DbSet<CommonMisconception> CommonMisconceptions { get; set; }
    public DbSet<KeyRelation> KeyRelations { get; set; }
    public DbSet<ConversationAttempt> ConversationAttempts { get; set; }
    public DbSet<ConversationTurn> ConversationTurns { get; set; }
    public DbSet<TurnEvaluation> TurnEvaluations { get; set; }

    public ElaborationsContext(DbContextOptions<ElaborationsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("elaborations");

        ConfigureConceptElaborationTasks(modelBuilder);
        ConfigureConversations(modelBuilder);
    }

    private static void ConfigureConceptElaborationTasks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConceptElaborationTask>()
            .HasMany(cet => cet.KeyPropositions)
            .WithOne()
            .HasForeignKey(kp => kp.ConceptElaborationTaskId);

        modelBuilder.Entity<ConceptElaborationTask>()
            .HasMany(cet => cet.BoundaryConditions)
            .WithOne()
            .HasForeignKey(bc => bc.ConceptElaborationTaskId);

        modelBuilder.Entity<ConceptElaborationTask>()
            .HasMany(cet => cet.CommonMisconceptions)
            .WithOne()
            .HasForeignKey(cm => cm.ConceptElaborationTaskId);

        modelBuilder.Entity<ConceptElaborationTask>()
            .HasMany(cet => cet.KeyRelations)
            .WithOne()
            .HasForeignKey(kr => kr.ConceptElaborationTaskId);

        modelBuilder.Entity<ConceptElaborationTask>()
            .HasIndex(cet => new { cet.UnitId, cet.Order });

        modelBuilder.Entity<KeyRelation>()
            .HasOne(kr => kr.SourceKeyProposition)
            .WithMany()
            .HasForeignKey(kr => kr.SourceKeyPropositionId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        modelBuilder.Entity<KeyRelation>()
            .HasOne(kr => kr.TargetKeyProposition)
            .WithMany()
            .HasForeignKey(kr => kr.TargetKeyPropositionId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }

    private static void ConfigureConversations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConversationAttempt>()
            .HasMany(ca => ca.Turns)
            .WithOne()
            .HasForeignKey(ct => ct.ConversationAttemptId);

        modelBuilder.Entity<ConversationAttempt>()
            .HasIndex(ca => new { ca.ConceptElaborationTaskId, ca.LearnerId });

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
