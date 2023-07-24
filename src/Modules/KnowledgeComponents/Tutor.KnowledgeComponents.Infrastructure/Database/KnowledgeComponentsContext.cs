using Microsoft.EntityFrameworkCore;

namespace Tutor.KnowledgeComponents.Infrastructure.Database;

public class KnowledgeComponentsContext : DbContext
{
    public KnowledgeComponentsContext(DbContextOptions<KnowledgeComponentsContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("knowledge-components");
    }
}