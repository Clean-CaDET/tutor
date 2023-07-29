using Microsoft.EntityFrameworkCore;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Infrastructure.Database;

public class LanguageModelConversationsContext : DbContext
{
    public LanguageModelConversationsContext(DbContextOptions<LanguageModelConversationsContext> options) : base(options) {}

    public DbSet<TokenWallet> Tokens { get; set; }
    public DbSet<Conversation> Conversations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("languageModelConversations");
        modelBuilder.Entity<Conversation>().Property(e => e.LmMessages).HasColumnType("jsonb");
        modelBuilder.Entity<Conversation>().Property(e => e.Messages).HasColumnType("jsonb");
    }
}
