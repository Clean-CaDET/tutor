using Microsoft.EntityFrameworkCore;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Infrastructure.Database;

public class LearningTasksContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<LearningTask> LearningTasks { get; set; }
    public DbSet<Standard> Standards { get; set; }

    public LearningTasksContext(DbContextOptions<LearningTasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LearningTask>()
            .HasMany(l => l.Steps)
            .WithOne()
            .HasForeignKey("LearningTaskId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.HasDefaultSchema("learningTasks");
        modelBuilder.Entity<Activity>().Property(a => a.Examples).HasColumnType("jsonb");
        modelBuilder.Entity<Activity>().Property(s => s.SubmissionFormat).HasColumnType("jsonb");
        modelBuilder.Entity<Activity>()
            .HasMany(a => a.Standards)
            .WithOne()
            .HasForeignKey("ActivityId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Activity>().HasIndex(a => new { a.UnitId, a.Code }).IsUnique();
    }
}