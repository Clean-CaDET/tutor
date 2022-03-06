using Microsoft.EntityFrameworkCore;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.NameChecker;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentEvents.ShortAnswerQuestions;
using Tutor.Core.DomainModel.Feedback;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Infrastructure.Database
{
    public class TutorContext : DbContext
    {
        #region Domain Model

        public DbSet<Unit> Units { get; set; }
        public DbSet<KnowledgeComponent> KnowledgeComponents { get; set; }
        public DbSet<AssessmentEvent> AssessmentEvents { get; set; }
        public DbSet<InstructionalEvent> InstructionalEvents { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Mrq> MultiResponseQuestions { get; set; }
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
        public DbSet<MetricRangeRule> MetricRangeRules { get; set; }
        public DbSet<ChallengeHint> ChallengeHints { get; set; }

        #endregion

        #region Submissions

        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SaqSubmission> SaqSubmissions { get; set; }
        public DbSet<ArrangeTaskSubmission> ArrangeTaskSubmissions { get; set; }
        public DbSet<ArrangeTaskContainerSubmission> ArrangeTaskContainerSubmissions { get; set; }
        public DbSet<ChallengeSubmission> ChallengeSubmissions { get; set; }
        public DbSet<MrqSubmission> MrqSubmissions { get; set; }

        #endregion

        #region Feedbacks

        public DbSet<EmotionsFeedback> EmotionsFeedbacks { get; set; }

        #endregion

        public DbSet<Learner> Learners { get; set; }
        public DbSet<KnowledgeComponentMastery> KcMastery { get; set; }

        public TutorContext(DbContextOptions<TutorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Text>().ToTable("Texts");
            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Video>().ToTable("Videos");
            modelBuilder.Entity<Mrq>().ToTable("MultiResponseQuestions");
            modelBuilder.Entity<Saq>().ToTable("ShortAnswerQuestions");
            
            ConfigureArrangeTask(modelBuilder);
            ConfigureChallenge(modelBuilder);
            ConfigureKnowledgeComponent(modelBuilder);

            modelBuilder.Entity<Learner>()
                .OwnsOne(l => l.Workspace)
                .Property(w => w.Path).HasColumnName("WorkspacePath");
        }

        private static void ConfigureArrangeTask(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArrangeTask>().ToTable("ArrangeTasks");

            modelBuilder.Entity<ArrangeTaskSubmission>()
                .HasMany(at => at.Containers)
                .WithOne()
                .HasForeignKey("SubmissionId");
        }

        private static void ConfigureChallenge(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>().ToTable("Challenges");

            modelBuilder.Entity<BannedWordsChecker>().ToTable("BannedWordsCheckers");
            modelBuilder.Entity<RequiredWordsChecker>().ToTable("RequiredWordsCheckers");
            modelBuilder.Entity<BasicMetricChecker>().ToTable("BasicMetricCheckers");

            ConfigureBasicMetricChecker(modelBuilder);
        }

        private static void ConfigureBasicMetricChecker(ModelBuilder modelBuilder)
        {
            // Add the shadow property to the model
            modelBuilder.Entity<MetricRangeRule>()
                .Property<int?>("MetricCheckerForeignKey").IsRequired(false);

            // Use the shadow property as a foreign key
            modelBuilder.Entity<BasicMetricChecker>()
                .HasMany(b => b.MetricRanges)
                .WithOne()
                .HasForeignKey("MetricCheckerForeignKey");
        }

        private static void ConfigureKnowledgeComponent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeComponent>()
                .HasMany(kc => kc.KnowledgeComponents)
                .WithOne()
                .HasForeignKey("ParentId")
                .IsRequired(false);
        }
    }
}