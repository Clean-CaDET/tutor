using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.Postgres;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Infrastructure.Database;

public class LearningTasksContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<LearningTask> LearningTasks { get; set; }
    public DbSet<Standard> Standards { get; set; }
    public DbSet<TaskProgress> TaskProgresses { get; set; }
    public DbSet<StepProgress> StepProgresses { get; set; }
    public DbSet<StoredDomainEvent> Events { get; set; }

    public LearningTasksContext(DbContextOptions<LearningTasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LearningTask>()
            .HasMany(l => l.Steps)
            .WithOne()
            .HasForeignKey(s => s.LearningTaskId)
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
        modelBuilder.Entity<Activity>().HasIndex(a => new { a.LearningTaskId, a.Code }).IsUnique();
        modelBuilder.Entity<StepProgress>().Property(s => s.Evaluations).HasColumnType("jsonb");

        modelBuilder.Entity<TaskProgress>()
            .HasMany(t => t.StepProgresses)
            .WithOne()
            .HasForeignKey("TaskProgressId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LearningTask>()
            .HasMany<TaskProgress>()
            .WithOne()
            .HasForeignKey(tp => tp.LearningTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StoredDomainEvent>().Property(e => e.DomainEvent).HasColumnType("jsonb");
        modelBuilder.Entity<StoredDomainEvent>().HasIndex(e => e.TimeStamp);
    }
}