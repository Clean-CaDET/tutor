using Microsoft.EntityFrameworkCore;
using Tutor.LearningTasks.Core.Domain.Activities;

namespace Tutor.LearningTasks.Infrastructure.Database;

public class LearningTasksContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }

    public LearningTasksContext(DbContextOptions<LearningTasksContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("learningTasks");
        modelBuilder.Entity<Activity>().Property(a => a.Guidance).HasColumnType("jsonb");
        modelBuilder.Entity<Activity>().Property(a => a.Examples).HasColumnType("jsonb");
        modelBuilder.Entity<Activity>().Property(a => a.Subactivities).HasColumnType("jsonb");
    }
}