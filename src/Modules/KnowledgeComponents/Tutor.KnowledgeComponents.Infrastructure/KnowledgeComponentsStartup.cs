using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.KnowledgeComponents.API.Interfaces.Analysis;
using Tutor.KnowledgeComponents.API.Interfaces.Authoring;
using Tutor.KnowledgeComponents.API.Interfaces.Learning;
using Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;
using Tutor.KnowledgeComponents.API.Interfaces.Monitoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.MoveOn;
using Tutor.KnowledgeComponents.Core.Mappers;
using Tutor.KnowledgeComponents.Core.UseCases;
using Tutor.KnowledgeComponents.Core.UseCases.Analysis;
using Tutor.KnowledgeComponents.Core.UseCases.Authoring;
using Tutor.KnowledgeComponents.Core.UseCases.Learning;
using Tutor.KnowledgeComponents.Core.UseCases.Learning.Assessment;
using Tutor.KnowledgeComponents.Core.UseCases.Monitoring;
using Tutor.KnowledgeComponents.Infrastructure.Database;
using Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.Postgres;
using Tutor.KnowledgeComponents.Infrastructure.Database.Repositories;

namespace Tutor.KnowledgeComponents.Infrastructure;

public static class KnowledgeComponentsStartup
{
    public static IServiceCollection ConfigureKnowledgeComponentsModule(this IServiceCollection services)
    {
        SetupAutoMapper(services);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AnalyticsProfile).Assembly);
        services.AddAutoMapper(typeof(AssessmentItemsProfile).Assembly);
        services.AddAutoMapper(typeof(KnowledgeProfile).Assembly);
        services.AddAutoMapper(typeof(MasteryProfile).Assembly);
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IAssessmentAnalysisService, AssessmentAnalysisService>();
        services.AddScoped<IKnowledgeAnalysisService, KnowledgeAnalysisService>();

        services.AddScoped<IAssessmentService, AssessmentService>();
        services.AddScoped<IInstructionalItemsService, InstructionalItemsService>();
        services.AddScoped<IKnowledgeComponentService, KnowledgeComponentService>();

        services.AddScoped<IInstructionService, InstructionService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<IStatisticsService, StatisticsService>();
        services.AddScoped<IStructureService, StructureService>();

        services.AddScoped<IEvaluationService, EvaluationService>();
        services.AddScoped<IHelpService, HelpService>();
        services.AddScoped<ISelectionService, SelectionService>();

        services.AddScoped<ILearnerProgressService, LearnerProgressService>();

        services.AddScoped<IAssessmentFeedbackGenerator, RuleAssessmentFeedbackGenerator>();
        services.AddScoped<IAssessmentItemSelector, LeastCorrectAssessmentItemSelector>();
        services.AddScoped<IMoveOnCriteria, Passed>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IAssessmentItemRepository, AssessmentItemDatabaseRepository>();
        services.AddScoped<IInstructionalItemRepository, InstructionalItemDatabaseRepository>();
        services.AddScoped<IKnowledgeComponentRepository, KnowledgeComponentDatabaseRepository>();

        services.AddScoped<IKnowledgeMasteryRepository, KnowledgeMasteryDatabaseRepository>();

        services.AddScoped<IEventStore, PostgresStore>();

        services.AddScoped<IKnowledgeComponentsUnitOfWork, KnowledgeComponentsUnitOfWork>();
        services.AddDbContext<KnowledgeComponentsContext>(opt =>
            opt.UseNpgsql(CreateConnectionStringFromEnvironment()));
    }

    private static string CreateConnectionStringFromEnvironment()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "tutor-v4";
        var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
        var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "super";
        var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
        var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
    }
}