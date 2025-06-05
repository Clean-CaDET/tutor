using Microsoft.EntityFrameworkCore;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.Reflections;

namespace Tutor.Courses.Infrastructure.Database;

public class CoursesContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseOwnership> CourseOwnerships { get; set; }
    public DbSet<KnowledgeUnit> KnowledgeUnits { get; set; }
    public DbSet<Reflection> Reflections { get; set; }
    public DbSet<ReflectionQuestion> ReflectionQuestions { get; set; }
    public DbSet<ReflectionAnswer> ReflectionAnswers { get; set; }
    public DbSet<ReflectionQuestionCategory> ReflectionQuestionCategories { get; set; }
    public DbSet<SystemPrompt> SystemPrompts { get; set; }
    public DbSet<LearnerGroup> LearnerGroups { get; set; }
    public DbSet<UnitEnrollment> UnitEnrollments { get; set; }
    public DbSet<UnitProgressRating> UnitProgressRating { get; set; }
    public DbSet<WeeklyFeedback> WeeklyProgress { get; set; }
    public DbSet<WeeklyFeedbackQuestion> WeeklyFeedbackQuestions { get; set; }

    public CoursesContext(DbContextOptions<CoursesContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("courses");
        modelBuilder.Entity<KnowledgeUnit>().HasIndex(u => new { u.CourseId, u.Code }).IsUnique();
        modelBuilder.Entity<ReflectionAnswer>().Property(a => a.Answers).HasColumnType("jsonb");
        modelBuilder.Entity<LearnerGroup>().Property(e => e.LearnerIds).HasColumnType("jsonb");
        
        modelBuilder.Entity<UnitProgressRating>().Property(e => e.Feedback).HasColumnType("jsonb");
        modelBuilder.Entity<UnitProgressRating>()
            .HasOne<KnowledgeUnit>()
            .WithMany()
            .HasForeignKey(p => p.KnowledgeUnitId);
        modelBuilder.Entity<WeeklyFeedback>()
            .HasOne<Course>()
            .WithMany()
            .HasForeignKey(p => p.CourseId);
        modelBuilder.Entity<WeeklyFeedback>().Property(w => w.Opinions).HasColumnType("jsonb");
        modelBuilder.Entity<WeeklyFeedbackQuestion>().Property(q => q.Options).HasColumnType("jsonb");
    }
}