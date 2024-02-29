using Microsoft.EntityFrameworkCore;
using Tutor.LearningTasks.Core.Domain.Activities;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Infrastructure.Database;

public class LearningTasksContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<LearningTask> LearningTasks { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<Standard> Standards { get; set; }

    public LearningTasksContext(DbContextOptions<LearningTasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("learningTasks");
        modelBuilder.Entity<Activity>().Property(a => a.Guidance).HasColumnType("jsonb");
        modelBuilder.Entity<Activity>().Property(a => a.Examples).HasColumnType("jsonb");
        modelBuilder.Entity<Activity>().Property(a => a.Standards).HasColumnType("jsonb");
        modelBuilder.Entity<Activity>().Property(a => a.Subactivities).HasColumnType("jsonb");
        modelBuilder.Entity<Activity>().HasIndex(a => new { a.CourseId, a.Code }).IsUnique();

        modelBuilder.Entity<LearningTask>()
            .HasMany(l => l.Steps)
            .WithOne()
            .HasForeignKey("LearningTaskId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Step>().Property(s => s.SubmissionFormat).HasColumnType("jsonb");
        modelBuilder.Entity<Step>()
            .HasMany(l => l.Standards)
            .WithOne()
            .HasForeignKey("StepId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}