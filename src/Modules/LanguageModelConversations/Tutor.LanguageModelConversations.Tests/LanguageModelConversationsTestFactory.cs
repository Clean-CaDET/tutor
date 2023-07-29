using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Tests;
using Tutor.LanguageModelConversations.Infrastructure.Database;

namespace Tutor.LanguageModelConversations.Tests;

public class LanguageModelConversationsTestFactory : BaseTestFactory<LanguageModelConversationsContext>
{
    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LanguageModelConversationsContext>));
        services.Remove(descriptor!);
        services.AddDbContext<LanguageModelConversationsContext>(SetupTestContext());

        return services;
    }
}
