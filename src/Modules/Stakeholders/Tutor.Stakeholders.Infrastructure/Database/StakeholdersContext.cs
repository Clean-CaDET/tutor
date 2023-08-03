using Microsoft.EntityFrameworkCore;
using Tutor.Stakeholders.Core.Domain;

namespace Tutor.Stakeholders.Infrastructure.Database;

public class StakeholdersContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Learner> Learners { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    public StakeholdersContext(DbContextOptions<StakeholdersContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("stakeholders");

        modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

        ConfigureStakeholder(modelBuilder);
    }

    private static void ConfigureStakeholder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stakeholder>().UseTpcMappingStrategy();
        modelBuilder.Entity<Stakeholder>().Property(s => s.IsArchived).HasDefaultValue(false);
        modelBuilder.Entity<Stakeholder>()
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Stakeholder>(s => s.UserId);

        modelBuilder.Entity<Learner>().Property(l => l.LearnerType).HasDefaultValue(LearnerType.Regular);
    }
}