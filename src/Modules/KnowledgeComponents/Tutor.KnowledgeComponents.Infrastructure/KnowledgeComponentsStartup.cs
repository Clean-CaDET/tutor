using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.API.Public.Learning.Assessment;
using Tutor.KnowledgeComponents.API.Public.Monitoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;
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
        services.AddScoped<IAccessService, AccessServices>();

        services.AddScoped<IAssessmentAnalysisService, AssessmentAnalysisService>();
        services.AddScoped<IKnowledgeAnalysisService, KnowledgeAnalysisService>();
        services.AddScoped<IRatingService, RatingService>();

        services.AddScoped<IAssessmentService, AssessmentService>();
        services.AddScoped<IInstructionalItemsService, InstructionalItemsService>();
        services.AddScoped<IKnowledgeComponentService, KnowledgeComponentService>();
        services.AddScoped<IKnowledgeComponentCloner, KnowledgeComponentService>();

        services.AddScoped<IInstructionService, InstructionService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<IStatisticsService, StatisticsService>();
        services.AddScoped<IStructureService, StructureService>();

        services.AddScoped<IEvaluationService, EvaluationService>();
        services.AddScoped<IHelpService, HelpService>();
        services.AddScoped<ISelectionService, SelectionService>();

        services.AddScoped<ILearnerMasteryService, LearnerMasteryService>();
        services.AddScoped<IMasteryFactory, LearnerMasteryService>();

        services.AddScoped<IAssessmentFeedbackGenerator, RuleAssessmentFeedbackGenerator>();
        services.AddScoped<IAssessmentItemSelector, LeastCorrectAssessmentItemSelector>();
        services.AddScoped<IMoveOnCriteria, Passed>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<KnowledgeComponentRating>),
            typeof(CrudDatabaseRepository<KnowledgeComponentRating, KnowledgeComponentsContext>));

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