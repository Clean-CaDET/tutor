using Microsoft.EntityFrameworkCore;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.DomainModel.AssessmentItems.MultiChoiceQuestions;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.InstructorModel;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Core.LearnerModel.Feedback;
using Tutor.Core.LearnerModel.Notes;
using Tutor.Infrastructure.Security.Authentication.Users;

namespace Tutor.Infrastructure.Database
{
    public class TutorContext : DbContext
    {
        #region Domain Model
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

        #region Feedback & Notes
        public DbSet<EmotionsFeedback> EmotionsFeedbacks { get; set; }
        public DbSet<TutorImprovementFeedback> TutorImprovementFeedbacks { get; set; }
        public DbSet<Note> Notes { get; set; }

        #endregion

        #region Learners
        public DbSet<Learner> Learners { get; set; }
        public DbSet<LearnerGroup> LearnerGroups { get; set; }
        public DbSet<GroupMembership> GroupMemberships { get; set; }
        public DbSet<UnitEnrollment> UnitEnrollments { get; set; }
        public DbSet<KnowledgeComponentMastery> KcMasteries { get; set; }
        public DbSet<AssessmentItemMastery> AssessmentItemMasteries { get; set; }
        #endregion

        public DbSet<User> Users { get; set; }
        
        #region Instructors
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorCourse> InstructorsCourses { get; set; }
        #endregion

        public TutorContext(DbContextOptions<TutorContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
            ConfigureKcMastery(modelBuilder);

            modelBuilder.Entity<GroupMembership>()
                .HasOne(g => g.Learner)
                .WithMany();
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
                .HasMany(kc => kc.KnowledgeComponents)
                .WithOne()
                .HasForeignKey(kc => kc.ParentId)
                .IsRequired(false);
        }

        private static void ConfigureKcMastery(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeComponentMastery>().Ignore(kcm => kcm.MoveOnCriteria);
            modelBuilder.Entity<KnowledgeComponentMastery>()
                .HasOne(kcm => kcm.KnowledgeComponent)
                .WithMany();
            modelBuilder.Entity<KnowledgeComponentMastery>()
                .HasMany(kcm => kcm.AssessmentMasteries)
                .WithOne();
        }
    }
}