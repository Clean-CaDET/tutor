using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.BuildingBlocks.Infrastructure.Interceptors;
using Tutor.Elaborations.API.Internal;
using Tutor.Elaborations.API.Public;
using Tutor.Elaborations.API.Public.Authoring;
using Tutor.Elaborations.API.Public.Learning;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.Mappers;
using Tutor.Elaborations.Core.UseCases;
using Tutor.Elaborations.Core.UseCases.Authoring;
using Tutor.Elaborations.Core.UseCases.Learning;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Monitoring;
using Tutor.Elaborations.Infrastructure.Database;
using Tutor.Elaborations.Infrastructure.Database.Repositories;

namespace Tutor.Elaborations.Infrastructure;

public static class ElaborationsStartup
{
    public static IServiceCollection ConfigureElaborationsModule(this IServiceCollection services)
    {
        SetupAutoMapper(services);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConceptElaborationTaskProfile).Assembly);
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddProxiedScoped<IConceptElaborationTaskService, ConceptElaborationTaskService>();
        services.AddProxiedScoped<IConversationService, ConversationService>();
        services.AddProxiedScoped<IAccessServices, AccessServices>();
        services.AddProxiedScoped<IConceptElaborationTaskQuerier, ConceptElaborationTaskQuerier>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IConceptElaborationTaskRepository, ConceptElaborationTaskDatabaseRepository>();
        services.AddScoped<IConversationAttemptRepository, ConversationAttemptDatabaseRepository>();

        services.AddScoped<IAgentOrchestrator, AgentOrchestrator>();

        services.AddScoped<IElaborationsUnitOfWork, ElaborationsUnitOfWork>();

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(DbConnectionStringBuilder.Build("elaborations"));
        dataSourceBuilder.EnableDynamicJson();
        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<ElaborationsContext>(opt =>
            opt.UseNpgsql(dataSource,
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "elaborations")));
    }
}
