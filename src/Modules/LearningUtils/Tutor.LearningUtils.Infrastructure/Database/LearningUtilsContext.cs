using Microsoft.EntityFrameworkCore;
using Tutor.LearningUtils.Core.Domain;

namespace Tutor.LearningUtils.Infrastructure.Database;

public class LearningUtilsContext : DbContext
{
    public DbSet<EmotionsFeedback> EmotionsFeedbacks { get; set; }
    public DbSet<ImprovementFeedback> ImprovementFeedbacks { get; set; }
    public DbSet<Note> Notes { get; set; }
    
    public LearningUtilsContext(DbContextOptions<LearningUtilsContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("learningUtils");
    }
}