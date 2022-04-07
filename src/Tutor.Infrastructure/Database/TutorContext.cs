using Microsoft.EntityFrameworkCore;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.DomainModel.Feedback;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.DomainModel.Notes;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

namespace Tutor.Infrastructure.Database
{
    public class TutorContext : DbContext
    {
        #region Domain Model

        public DbSet<Unit> Units { get; set; }
        public DbSet<KnowledgeComponent> KnowledgeComponents { get; set; }
        public DbSet<AssessmentItem> AssessmentItems { get; set; }
        public DbSet<InstructionalItem> InstructionalItems { get; set; }
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
        public DbSet<TutorImprovementFeedback> TutorImprovementFeedbacks { get; set; }

        #endregion

        public DbSet<Learner> Learners { get; set; }
        public DbSet<UnitEnrollment> UnitEnrollments { get; set; }
        public DbSet<KnowledgeComponentMastery> KcMasteries { get; set; }

        public TutorContext(DbContextOptions<TutorContext> options) : base(options)
        {
        }
        
        public DbSet<Note> Notes { get; set; }

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
            ConfigureKcMastery(modelBuilder);

            modelBuilder.Entity<Learner>()
                .OwnsOne(l => l.Workspace)
                .Property(w => w.Path).HasColumnName("WorkspacePath");
            modelBuilder.Entity<KnowledgeComponentMastery>()
                .HasOne(kcm => kcm.KnowledgeComponent)
                .WithMany();
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
        }

        private static void ConfigureKnowledgeComponent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeComponent>()
                .HasMany(kc => kc.KnowledgeComponents)
                .WithOne()
                .HasForeignKey("ParentId")
                .IsRequired(false);
        }

        private static void ConfigureKcMastery(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeComponentMastery>().Ignore(kcm => kcm.MoveOnCriteria);
            modelBuilder.Entity<KnowledgeComponentMastery>().Ignore(kcm => kcm.IsCompleted);
        }
    }
}