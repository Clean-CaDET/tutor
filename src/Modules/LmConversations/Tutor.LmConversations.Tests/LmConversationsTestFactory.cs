using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Tests;
using Tutor.LmConversations.Infrastructure.Database;

namespace Tutor.LmConversations.Tests;

public class LmConversationsTestFactory : BaseTestFactory<LmConversationsContext>
{
    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LmConversationsContext>));
        services.Remove(descriptor!);
        services.AddDbContext<LmConversationsContext>(SetupTestContext());

        return services;
    }
}
