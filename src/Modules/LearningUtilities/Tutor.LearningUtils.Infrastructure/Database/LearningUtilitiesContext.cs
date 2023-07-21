using Microsoft.EntityFrameworkCore;
using Tutor.LearningUtils.Core.Domain;

namespace Tutor.LearningUtils.Infrastructure.Database;

public class LearningUtilitiesContext : DbContext
{
    public DbSet<EmotionsFeedback> EmotionsFeedbacks { get; set; }
    public DbSet<ImprovementFeedback> ImprovementFeedbacks { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<KnowledgeComponentRating> KnowledgeComponentRatings { get; set; }
    
    public LearningUtilitiesContext(DbContextOptions<LearningUtilitiesContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("learningUtilities");

        ConfigureLearningUtilities(modelBuilder);
    }
    
    private static void ConfigureLearningUtilities(ModelBuilder modelBuilder)
    {
    }
}