using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Tests;
using Tutor.Courses.Infrastructure.Database;
using Tutor.KnowledgeComponents.Infrastructure.Database;
using Tutor.LearningTasks.Infrastructure.Database;
using Tutor.Stakeholders.Infrastructure.Database;

namespace Tutor.Courses.Tests;

public class CoursesTestFactory : BaseTestFactory<CoursesContext>
{
    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CoursesContext>));
        services.Remove(descriptor!);
        services.AddDbContext<CoursesContext>(SetupTestContext());

        descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<KnowledgeComponentsContext>));
        services.Remove(descriptor!);
        services.AddDbContext<KnowledgeComponentsContext>(SetupTestContext());

        descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LearningTasksContext>));
        services.Remove(descriptor!);
        services.AddDbContext<LearningTasksContext>(SetupTestContext());

        descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<StakeholdersContext>));
        services.Remove(descriptor!);
        services.AddDbContext<StakeholdersContext>(SetupTestContext());

        return services;
    }
}
