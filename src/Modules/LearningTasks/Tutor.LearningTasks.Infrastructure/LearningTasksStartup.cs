using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.DefaultEventSerializer;
using Tutor.BuildingBlocks.Infrastructure.Interceptors;
using Tutor.LearningTasks.API.Internal;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.API.Public.Monitoring;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;
using Tutor.LearningTasks.Core.Mappers;
using Tutor.LearningTasks.Core.UseCases;
using Tutor.LearningTasks.Core.UseCases.Authoring;
using Tutor.LearningTasks.Core.UseCases.Learning;
using Tutor.LearningTasks.Core.UseCases.Monitoring;
using Tutor.LearningTasks.Infrastructure.Database;
using Tutor.LearningTasks.Infrastructure.Database.EventStore;
using Tutor.LearningTasks.Infrastructure.Database.EventStore.Postgres;
using Tutor.LearningTasks.Infrastructure.Database.Repositories;

namespace Tutor.LearningTasks.Infrastructure;

public static class LearningTasksStartup
{
    public static IServiceCollection ConfigureLearningTasksModule(this IServiceCollection services)
    {
        SetupAutoMapper(services);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(LearningTasksProfile).Assembly);
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddProxiedScoped<ILearningTaskService, LearningTaskService>();
        services.AddProxiedScoped<ILearningTaskCloner, LearningTaskService>();
        services.AddProxiedScoped<ITaskQuerier, LearningTaskService>();
        services.AddProxiedScoped<ITaskService, TaskService>();
        services.AddProxiedScoped<ITaskProgressService, TaskProgressService>();
        services.AddProxiedScoped<ITaskProgressQuerier, TaskProgressService>();
        services.AddProxiedScoped<ITaskProgressMonitor, TaskProgressMonitor>();
        services.AddProxiedScoped<IAccessServices, AccessServices>();
        services.AddProxiedScoped<IGradingService, GradingService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<ILearningTaskRepository, LearningTaskDatabaseRepository>();
        services.AddScoped<ITaskProgressRepository, TaskProgressDatabaseRepository>();
        services.AddScoped(typeof(IEventStore<TaskProgressEvent>), typeof(PostgresStore<TaskProgressEvent>));
        services.AddSingleton<IEventSerializer<TaskProgressEvent>>(new DefaultEventSerializer<TaskProgressEvent>(EventSerializationConfiguration.EventRelatedTypes));

        services.AddScoped<ILearningTasksUnitOfWork, LearningTasksUnitOfWork>();
        services.AddDbContext<LearningTasksContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("learningTasks"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "learningTasks")));
    }
}