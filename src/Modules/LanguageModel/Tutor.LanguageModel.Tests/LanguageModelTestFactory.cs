using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Tests;
using Tutor.LanguageModel.Infrastructure.Database;

namespace Tutor.LanguageModel.Tests;

public class LanguageModelTestFactory : BaseTestFactory<LanguageModelContext>
{
    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LanguageModelContext>));
        services.Remove(descriptor!);
        services.AddDbContext<LanguageModelContext>(SetupTestContext());

        return services;
    }
}
