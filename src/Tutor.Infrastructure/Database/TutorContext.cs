using Microsoft.EntityFrameworkCore;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.MetricChecker;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges.FulfillmentStrategy.NameChecker;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.Learners;
using Tutor.Core.ProgressModel.Feedback;
using Tutor.Core.ProgressModel.Submissions;

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
        //TODO: Examine which DbSets we don't need directly and remove them, while configuring EFCore to generate the tables.
        //TODO: Enable value object storing to remove the appropriate tables - e.g. MRQAnswer, ATContainer and ATElement
        public DbSet<MRQContainer> MultiResponseQuestions { get; set; }
        public DbSet<MRQAnswer> MRQAnswers { get; set; }
        public DbSet<ArrangeTask> ArrangeTasks { get; set; }
        public DbSet<ArrangeTaskContainer> ArrangeTaskContainers { get; set; }
        public DbSet<ArrangeTaskElement> ArrangeTaskElements { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<ChallengeFulfillmentStrategy> ChallengeFulfillmentStrategies { get; set; }
        public DbSet<BasicMetricChecker> BasicMetricCheckers { get; set; }
        public DbSet<BasicNameChecker> BasicNameCheckers { get; set; }
        public DbSet<MetricRangeRule> MetricRangeRules { get; set; }
        public DbSet<ChallengeHint> ChallengeHints { get; set; }

        #endregion

        #region Progress Model

        public DbSet<ArrangeTaskSubmission> ArrangeTaskSubmissions { get; set; }
        public DbSet<ArrangeTaskContainerSubmission> ArrangeTaskContainerSubmissions { get; set; }
        public DbSet<ChallengeSubmission> ChallengeSubmissions { get; set; }
        public DbSet<QuestionSubmission> QuestionSubmissions { get; set; }
        public DbSet<LearningObjectFeedback> LearningObjectFeedback { get; set; }

        #endregion

        public DbSet<Learner> Learners { get; set; }
        public DbSet<KnowledgeComponentMastery> KCMastery { get; set; }

        public TutorContext(DbContextOptions<TutorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Text>().ToTable("Texts");
            modelBuilder.Entity<Image>().ToTable("Images");
            modelBuilder.Entity<Video>().ToTable("Videos");
            modelBuilder.Entity<MRQContainer>().ToTable("MultiResponseQuestions");
            modelBuilder.Entity<ArrangeTask>().ToTable("ArrangeTasks");

            ConfigureChallenge(modelBuilder);

            modelBuilder.Entity<Learner>()
                .OwnsOne(l => l.Workspace)
                .Property(w => w.Path).HasColumnName("WorkspacePath");
        }

        private static void ConfigureChallenge(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Challenge>().ToTable("Challenges");

            modelBuilder.Entity<BasicNameChecker>().ToTable("BasicNameCheckers");
            modelBuilder.Entity<BasicMetricChecker>().ToTable("BasicMetricCheckers");

            ConfigureBasicMetricChecker(modelBuilder);
        }

        private static void ConfigureBasicMetricChecker(ModelBuilder modelBuilder)
        {
            //TODO: Look for patterns for better DBContext code organization when using Fluent API extensively.

            // Add the shadow property to the model
            modelBuilder.Entity<MetricRangeRule>()
                .Property<int?>("MetricCheckerForeignKey").IsRequired(false);

            // Use the shadow property as a foreign key
            modelBuilder.Entity<BasicMetricChecker>()
                .HasMany(b => b.MetricRanges)
                .WithOne()
                .HasForeignKey("MetricCheckerForeignKey");
        }
    }
}