using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Tests;
using Tutor.LearningTasks.Infrastructure.Database;

namespace Tutor.LearningTasks.Tests;

public class LearningTasksTestFactory : BaseTestFactory<LearningTasksContext>
{
    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LearningTasksContext>));
        services.Remove(descriptor!);
        services.AddDbContext<LearningTasksContext>(SetupTestContext());

        return services;
    }
}
