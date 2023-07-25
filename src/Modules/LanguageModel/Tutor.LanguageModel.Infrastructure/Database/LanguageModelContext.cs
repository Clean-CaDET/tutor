using Microsoft.EntityFrameworkCore;
using Tutor.LanguageModel.Core.Domain;

namespace Tutor.LanguageModel.Infrastructure.Database;

public class LanguageModelContext : DbContext
{
    public LanguageModelContext(DbContextOptions<LanguageModelContext> options) : base(options) {}

    public DbSet<Token> Tokens { get; set; }
    public DbSet<Chat> Chats { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("language-model");
    }
}
