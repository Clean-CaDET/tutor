using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Tests;
using Tutor.Courses.Infrastructure.Database;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Tests;

public class KnowledgeComponentsTestFactory : BaseTestFactory<KnowledgeComponentsContext>
{
    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<KnowledgeComponentsContext>));
        services.Remove(descriptor!);
        services.AddDbContext<KnowledgeComponentsContext>(SetupTestContext());

        descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CoursesContext>));
        services.Remove(descriptor!);
        services.AddDbContext<CoursesContext>(SetupTestContext());

        return services;
    }
}
