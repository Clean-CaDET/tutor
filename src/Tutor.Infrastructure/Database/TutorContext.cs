using Microsoft.EntityFrameworkCore;
using System;
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
    public DbSet<MrqItem> MrqItems { get; set; }
    public DbSet<Saq> ShortAnswerQuestions { get; set; }
    public DbSet<ArrangeTask> ArrangeTasks { get; set; }
    public DbSet<ArrangeTaskContainer> ArrangeTaskContainers { get; set; }
    public DbSet<ArrangeTaskElement> ArrangeTaskElements { get; set; }
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<ChallengeFulfillmentStrategy> ChallengeFulfillmentStrategies { get; set; }
    public DbSet<BasicMetricChecker> BasicMetricCheckers { get; set; }
    public DbSet<BannedWordsChecker> BannedWordsCheckers { get; set; }
    public DbSet<RequiredWordsChecker> RequiredWordsCheckers { get; set; }
    public DbSet<ChallengeHint> ChallengeHints { get; set; }

    #endregion
    #region Knowledge Mastery
    public DbSet<KnowledgeComponentMastery> KcMasteries { get; set; }
    public DbSet<AssessmentItemMastery> AssessmentItemMasteries { get; set; }
    #endregion
    #region Learning Utilities
    public DbSet<EmotionsFeedback> EmotionsFeedbacks { get; set; }
    public DbSet<TutorImprovementFeedback> TutorImprovementFeedbacks { get; set; }
    public DbSet<Note> Notes { get; set; }

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

        modelBuilder.Entity<Stakeholder>().UseTpcMappingStrategy();
        modelBuilder.Entity<Stakeholder>().Property(s => s.IsArchived).HasDefaultValue(false);

        ConfigureKnowledge(modelBuilder);
        ConfigureKnowledgeMastery(modelBuilder);
        ConfigureCourseIteration(modelBuilder);
    }

    private static void ConfigureKnowledge(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Markdown>().ToTable("Texts");
        modelBuilder.Entity<Image>().ToTable("Images");
        modelBuilder.Entity<Video>().ToTable("Videos");
        modelBuilder.Entity<Mrq>().ToTable("MultiResponseQuestions");
        modelBuilder.Entity<Mcq>().ToTable("MultiChoiceQuestions");
        modelBuilder.Entity<Saq>().ToTable("ShortAnswerQuestions");
        ConfigureArrangeTask(modelBuilder);
        ConfigureChallenge(modelBuilder);
        ConfigureKnowledgeComponent(modelBuilder);
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
            trackerBuilder.Ignore(tracker => tracker.Id);
        });
        kcmBuilder.Navigation(kcm => kcm.SessionTracker).IsRequired();
    }

    private static void ConfigureCourseIteration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupMembership>()
            .HasOne(g => g.Member)
            .WithMany();
    }
}