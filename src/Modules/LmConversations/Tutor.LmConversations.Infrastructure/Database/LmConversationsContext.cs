using Microsoft.EntityFrameworkCore;
using Tutor.LmConversations.Core.Domain;

namespace Tutor.LmConversations.Infrastructure.Database;

public class LmConversationsContext : DbContext
{
    public LmConversationsContext(DbContextOptions<LmConversationsContext> options) : base(options) {}

    public DbSet<Token> Tokens { get; set; }
    public DbSet<Conversation> Conversations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("lmConversations");
        modelBuilder.Entity<Conversation>().Property(e => e.LmMessages).HasColumnType("jsonb");
        modelBuilder.Entity<Conversation>().Property(e => e.Messages).HasColumnType("jsonb");
    }
}
