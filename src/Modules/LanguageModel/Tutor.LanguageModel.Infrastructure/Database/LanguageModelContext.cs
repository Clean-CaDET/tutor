using Microsoft.EntityFrameworkCore;

namespace Tutor.LanguageModel.Infrastructure.Database;

public class LanguageModelContext : DbContext
{
    public LanguageModelContext(DbContextOptions<LanguageModelContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("language-model");
    }
}
