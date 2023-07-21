using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Tests;
using Tutor.LearningUtils.Infrastructure.Database;

namespace Tutor.LearningUtils.Tests;

public class LearningUtilsTestFactory : BaseTestFactory<LearningUtilsContext>
{
    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LearningUtilsContext>));
        services.Remove(descriptor!);
        services.AddDbContext<LearningUtilsContext>(SetupTestContext());

        return services;
    }
}