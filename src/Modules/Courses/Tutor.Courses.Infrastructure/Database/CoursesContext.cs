using Microsoft.EntityFrameworkCore;
using Tutor.Courses.Core.Domain;

namespace Tutor.Courses.Infrastructure.Database;

public class CoursesContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<KnowledgeUnit> KnowledgeUnits { get; set; }
    public DbSet<LearnerGroup> LearnerGroups { get; set; }
    public DbSet<UnitEnrollment> UnitEnrollments { get; set; }
    public DbSet<UnitProgressRating> UnitProgressRating { get; set; }
    public DbSet<CourseOwnership> CourseOwnerships { get; set; }

    public CoursesContext(DbContextOptions<CoursesContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("courses");
        modelBuilder.Entity<LearnerGroup>().Property(e => e.LearnerIds).HasColumnType("jsonb");
        modelBuilder.Entity<UnitProgressRating>().Property(e => e.Feedback).HasColumnType("jsonb");
        
        modelBuilder.Entity<KnowledgeUnit>().HasIndex(u => new { u.CourseId, u.Code }).IsUnique();
    }
}