using Microsoft.EntityFrameworkCore;
using Tutor.LearningUtils.Core.Domain;

namespace Tutor.LearningUtils.Infrastructure.Database;

public class LearningUtilitiesContext : DbContext
{
    public DbSet<EmotionsFeedback> EmotionsFeedbacks { get; set; }
    public DbSet<ImprovementFeedback> ImprovementFeedbacks { get; set; }
    public DbSet<Note> Notes { get; set; }
    
    private static void ConfigureLearningUtilities(ModelBuilder modelBuilder)
    {
    }
}