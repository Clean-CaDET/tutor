using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.Structure;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.LearningUtilities;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Infrastructure.Database;

public class TutorContext : DbContext
{
    #region Knowledge
    public DbSet<Course> Courses { get; set; }
    public DbSet<KnowledgeUnit> KnowledgeUnits { get; set; }
    public DbSet<KnowledgeComponent> KnowledgeComponents { get; set; }
    public DbSet<AssessmentItem> AssessmentItems { get; set; }
    public DbSet<InstructionalItem> InstructionalItems { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Markdown> Texts { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Mrq> MultiResponseQuestions { get; set; }
    public DbSet<Mcq> MultiChoiceQuestions { get; set; }
    public DbSet<Saq> ShortAnswerQuestions { get; set; }
    public DbSet<ArrangeTask> ArrangeTasks { get; set; }
    public DbSet<ArrangeTaskContainer> ArrangeTaskContainers { get; set; }
    public DbSet<ArrangeTaskElement> ArrangeTaskElements { get; set; }
    public DbSet<Challenge> Challenges { get; set; }

    #endregion
    #region Knowledge Mastery
    public DbSet<KnowledgeComponentMastery> KcMasteries { get; set; }
    public DbSet<AssessmentItemMastery> AssessmentItemMasteries { get; set; }
    #endregion
    #region Learning Utilities
    public DbSet<EmotionsFeedback> EmotionsFeedbacks { get; set; }
    public DbSet<TutorImprovementFeedback> TutorImprovementFeedbacks { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Chat> Chats { get; set; }
    
    public DbSet<KnowledgeComponentRating> KnowledgeComponentRatings { get; set; }

    #endregion
    #region Course Iteration
    public DbSet<LearnerGroup> LearnerGroups { get; set; }
    public DbSet<GroupMembership> GroupMemberships { get; set; }
    public DbSet<UnitEnrollment> UnitEnrollments { get; set; }
    #endregion
    #region Stakeholders
    public DbSet<User> Users { get; set; }
    public DbSet<Learner> Learners { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<CourseOwnership> CourseOwnerships { get; set; }
    #endregion

    public TutorContext(DbContextOptions<TutorContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

        modelBuilder.Entity<CourseOwnership>()
            .HasOne(c => c.Instructor)
            .WithMany()
            .HasForeignKey(c => c.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CourseOwnership>()
            .HasOne(c => c.Course)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LearnerGroup>()
            .HasMany(g => g.Membership)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        ConfigureStakeholder(modelBuilder);
        ConfigureKnowledge(modelBuilder);
        ConfigureKnowledgeMastery(modelBuilder);
        ConfigureCourseIteration(modelBuilder);
        ConfigureLearningUtilities(modelBuilder);
    }

    private static void ConfigureStakeholder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stakeholder>().UseTpcMappingStrategy();
        modelBuilder.Entity<Stakeholder>().Property(s => s.IsArchived).HasDefaultValue(false);
        modelBuilder.Entity<Stakeholder>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Stakeholder>(s => s.UserId);

        modelBuilder.Entity<Learner>().Property(l => l.LearnerType).HasDefaultValue(LearnerType.Regular);
    }

    private static void ConfigureKnowledge(ModelBuilder modelBuilder)
    {
        ConfigureInstructionalItems(modelBuilder);

        modelBuilder.Entity<AssessmentItem>()
            .Property(item => item.Hints)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<Hint>>(v, (JsonSerializerOptions)null),
                new ValueComparer<List<Hint>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c));
        ConfigureQuestions(modelBuilder);
        ConfigureArrangeTask(modelBuilder);
        ConfigureChallenge(modelBuilder);
        ConfigureKnowledgeComponent(modelBuilder);
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

    private static void ConfigureQuestions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mrq>().ToTable("MultiResponseQuestions")
            .Property(m => m.Items)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<MrqItem>>(v, (JsonSerializerOptions)null),
                new ValueComparer<List<MrqItem>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c));
        modelBuilder.Entity<Mcq>().ToTable("MultiChoiceQuestions");
        modelBuilder.Entity<Saq>().ToTable("ShortAnswerQuestions");
    }

    private static void ConfigureArrangeTask(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArrangeTask>().ToTable("ArrangeTasks");
    }

    private static void ConfigureChallenge(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Challenge>().ToTable("Challenges");

        modelBuilder.Entity<BannedWordsChecker>().ToTable("BannedWordsCheckers");
        modelBuilder.Entity<RequiredWordsChecker>().ToTable("RequiredWordsCheckers");
        modelBuilder.Entity<BasicMetricChecker>().ToTable("BasicMetricCheckers");
        modelBuilder.Entity<ChallengeFulfillmentStrategy>().ToTable("ChallengeFulfillmentStrategies");
        modelBuilder.Entity<ChallengeHint>().ToTable("ChallengeHints");
    }

    private static void ConfigureKnowledgeComponent(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KnowledgeComponent>()
            .HasMany<KnowledgeComponent>()
            .WithOne()
            .HasForeignKey(kc => kc.ParentId)
            .IsRequired(false);
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
            .HasOne<AssessmentItem>()
            .WithMany()
            .HasForeignKey(aim => aim.AssessmentItemId);
    }

    private static void ConfigureCourseIteration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupMembership>()
            .HasOne(g => g.Member)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UnitEnrollment>()
            .HasOne<Learner>()
            .WithMany()
            .HasForeignKey(u => u.LearnerId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private static void ConfigureLearningUtilities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TutorImprovementFeedback>()
            .HasOne<Learner>()
            .WithMany()
            .HasForeignKey(t => t.LearnerId);
        modelBuilder.Entity<TutorImprovementFeedback>()
            .HasOne<KnowledgeUnit>()
            .WithMany()
            .HasForeignKey(t => t.UnitId);

        modelBuilder.Entity<EmotionsFeedback>()
            .HasOne<Learner>()
            .WithMany()
            .HasForeignKey(e => e.LearnerId);
        modelBuilder.Entity<EmotionsFeedback>()
            .HasOne<KnowledgeComponent>()
            .WithMany()
            .HasForeignKey(e => e.KnowledgeComponentId);

        modelBuilder.Entity<Note>()
            .HasOne<Learner>()
            .WithMany()
            .HasForeignKey(n => n.LearnerId);
        modelBuilder.Entity<Note>()
            .HasOne<KnowledgeUnit>()
            .WithMany()
            .HasForeignKey(n => n.UnitId);
    }
}