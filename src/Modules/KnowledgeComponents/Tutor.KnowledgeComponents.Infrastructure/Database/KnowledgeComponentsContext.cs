using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Infrastructure.Database;

public class KnowledgeComponentsContext : DbContext
{
    public DbSet<KnowledgeComponent> KnowledgeComponents { get; set; }
    public DbSet<AssessmentItem> AssessmentItems { get; set; }
    public DbSet<InstructionalItem> InstructionalItems { get; set; }
    public DbSet<KnowledgeComponentMastery> KcMasteries { get; set; }
    public DbSet<StoredDomainEvent> Events { get; set; }

    public KnowledgeComponentsContext(DbContextOptions<KnowledgeComponentsContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("knowledgeComponents");

        ConfigureKnowledge(modelBuilder);
        ConfigureKnowledgeMastery(modelBuilder);

        modelBuilder.Entity<StoredDomainEvent>().Property(e => e.DomainEvent).HasColumnType("jsonb");
        modelBuilder.Entity<StoredDomainEvent>().HasIndex(e => e.TimeStamp);
    }

    private static void ConfigureKnowledge(ModelBuilder modelBuilder)
    {
        ConfigureKnowledgeComponent(modelBuilder);
        ConfigureInstructionalItems(modelBuilder);
        ConfigureAssessmentItems(modelBuilder);
    }

    private static void ConfigureKnowledgeComponent(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KnowledgeComponent>()
            .HasMany<KnowledgeComponent>()
            .WithOne()
            .HasForeignKey(kc => kc.ParentId)
            .IsRequired(false);

        modelBuilder.Entity<KnowledgeComponent>().HasIndex(kc => new { kc.KnowledgeUnitId, kc.Code }).IsUnique();
    }

    private static void ConfigureInstructionalItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InstructionalItem>()
            .HasDiscriminator<string>("ItemType")
            .HasValue<Markdown>("Text")
            .HasValue<Image>("Image")
            .HasValue<Video>("Video");

        modelBuilder.Entity<Image>()
            .Property(i => i.Url)
            .HasColumnName("Url");
        modelBuilder.Entity<Image>()
            .Property(i => i.Caption)
            .HasColumnName("Caption");
        modelBuilder.Entity<Video>()
            .Property(v => v.Url)
            .HasColumnName("Url");
        modelBuilder.Entity<Video>()
            .Property(v => v.Caption)
            .HasColumnName("Caption");
    }

    private static void ConfigureAssessmentItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssessmentItem>()
            .Property(item => item.Hints).HasColumnType("jsonb");

        modelBuilder.Entity<Mrq>().ToTable("MultiResponseQuestions")
            .Property(m => m.Items).HasColumnType("jsonb");
        modelBuilder.Entity<Mcq>().ToTable("MultiChoiceQuestions");
        modelBuilder.Entity<Saq>().ToTable("ShortAnswerQuestions");
    }

    private static void ConfigureKnowledgeMastery(ModelBuilder modelBuilder)
    {
        var kcmBuilder = modelBuilder.Entity<KnowledgeComponentMastery>();
        kcmBuilder.Ignore(kcm => kcm.MoveOnCriteria);
        kcmBuilder.Property(kcm => kcm.Mastery).HasDefaultValue(0);
        kcmBuilder.Property(kcm => kcm.IsStarted).HasDefaultValue(false);
        kcmBuilder.Property(kcm => kcm.IsSatisfied).HasDefaultValue(false);
        kcmBuilder.Property(kcm => kcm.IsCompleted).HasDefaultValue(false);
        kcmBuilder.Property(kcm => kcm.IsPassed).HasDefaultValue(false);
        kcmBuilder.HasMany(kcm => kcm.AssessmentItemMasteries).WithOne().IsRequired();
        kcmBuilder.OwnsOne(kcm => kcm.SessionTracker, trackerBuilder =>
        {
            trackerBuilder.Property(tracker => tracker.CountOfSessions).IsRequired().HasDefaultValue(0);
            trackerBuilder.Property(tracker => tracker.DurationOfFinishedSessions).IsRequired().HasDefaultValue(TimeSpan.Zero);
            trackerBuilder.Property(tracker => tracker.IsPaused).IsRequired().HasDefaultValue(false);
            trackerBuilder.Property(tracker => tracker.DurationOfFinishedPauses).IsRequired().HasDefaultValue(TimeSpan.Zero);
            trackerBuilder.Ignore(tracker => tracker.Id);
        });
        kcmBuilder.Navigation(kcm => kcm.SessionTracker).IsRequired();
        kcmBuilder
            .HasOne<KnowledgeComponent>()
            .WithMany()
            .HasForeignKey(kcm => kcm.KnowledgeComponentId);

        modelBuilder.Entity<AssessmentItemMastery>()
            .ToTable("AssessmentItemMasteries")
            .HasOne<AssessmentItem>()
            .WithMany()
            .HasForeignKey(aim => aim.AssessmentItemId);
    }
}