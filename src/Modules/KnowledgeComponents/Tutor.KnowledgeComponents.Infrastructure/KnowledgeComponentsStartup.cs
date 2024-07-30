using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.BuildingBlocks.Infrastructure.Interceptors;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.API.Public.Learning.Assessment;
using Tutor.KnowledgeComponents.API.Public.Monitoring;
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
using Tutor.KnowledgeComponents.Infrastructure.Database.EventStore;
using Tutor.KnowledgeComponents.Infrastructure.Database.EventStore.DefaultEventSerializer;
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
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(AnalyticsProfile).Assembly);
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddProxiedScoped<IAccessService, AccessServices>();

        services.AddProxiedScoped<IAssessmentAnalysisService, AssessmentAnalysisService>();
        services.AddProxiedScoped<IMisconceptionAnalysisService, MisconceptionAnalysisService>();
        services.AddProxiedScoped<IKnowledgeAnalysisService, KnowledgeAnalysisService>();

        services.AddProxiedScoped<IAssessmentService, AssessmentService>();
        services.AddProxiedScoped<IInstructionalItemsService, InstructionalItemsService>();
        services.AddProxiedScoped<IKnowledgeComponentService, KnowledgeComponentService>();
        services.AddProxiedScoped<IKnowledgeComponentCloner, KnowledgeComponentService>();

        services.AddProxiedScoped<IInstructionService, InstructionService>();
        services.AddProxiedScoped<ISessionService, SessionService>();
        services.AddProxiedScoped<IStatisticsService, StatisticsService>();
        services.AddProxiedScoped<IStructureService, StructureService>();
        services.AddProxiedScoped<IKnowledgeMasteryQuerier, StructureService>();

        services.AddProxiedScoped<IEvaluationService, EvaluationService>();
        services.AddProxiedScoped<IHelpService, HelpService>();
        services.AddProxiedScoped<ISelectionService, SelectionService>();

        services.AddProxiedScoped<ILearnerMasteryService, LearnerMasteryService>();
        services.AddProxiedScoped<IMasteryFactory, LearnerMasteryService>();

        services.AddProxiedScoped<IAssessmentFeedbackGenerator, RuleAssessmentFeedbackGenerator>();
        services.AddProxiedScoped<IAssessmentItemSelector, LeastCorrectAssessmentItemSelector>();
        services.AddProxiedScoped<IMoveOnCriteria, Passed>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IAssessmentItemRepository, AssessmentItemDatabaseRepository>();
        services.AddScoped<IInstructionalItemRepository, InstructionalItemDatabaseRepository>();
        services.AddScoped<IKnowledgeComponentRepository, KnowledgeComponentDatabaseRepository>();

        services.AddScoped<IKnowledgeMasteryRepository, KnowledgeMasteryDatabaseRepository>();

        services.AddScoped<IEventStore, PostgresStore>();
        services.AddSingleton<IEventSerializer>(new DefaultEventSerializer(EventSerializationConfiguration.EventRelatedTypes));

        services.AddScoped<IKnowledgeComponentsUnitOfWork, KnowledgeComponentsUnitOfWork>();
        services.AddDbContext<KnowledgeComponentsContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("knowledgeComponents"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "knowledgeComponents")));
    }
}