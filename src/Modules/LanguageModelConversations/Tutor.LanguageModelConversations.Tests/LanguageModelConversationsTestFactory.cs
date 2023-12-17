using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Tests;
using Tutor.Courses.Infrastructure.Database;
using Tutor.KnowledgeComponents.Infrastructure.Database;
using Tutor.LanguageModelConversations.Infrastructure.Database;

namespace Tutor.LanguageModelConversations.Tests;

public class LanguageModelConversationsTestFactory : BaseTestFactory<LanguageModelConversationsContext>
{
    protected override IServiceCollection ReplaceNeededDbContexts(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<LanguageModelConversationsContext>));
        services.Remove(descriptor!);
        services.AddDbContext<LanguageModelConversationsContext>(SetupTestContext());

        descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CoursesContext>));
        services.Remove(descriptor!);
        services.AddDbContext<CoursesContext>(SetupTestContext());

        descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<KnowledgeComponentsContext>));
        services.Remove(descriptor!);
        services.AddDbContext<KnowledgeComponentsContext>(SetupTestContext());

        return services;
    }
}
