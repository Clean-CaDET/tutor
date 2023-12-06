using Microsoft.EntityFrameworkCore;

namespace Tutor.LearningTasks.Infrastructure.Database;

public class LearningTasksContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("learningTasks");
    }
}

