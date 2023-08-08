using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.BuildingBlocks.Infrastructure.Interceptors;
using Tutor.LearningUtils.API.Public;
using Tutor.LearningUtils.Core.Domain.RepositoryInterfaces;
using Tutor.LearningUtils.Core.Mappers;
using Tutor.LearningUtils.Core.UseCases;
using Tutor.LearningUtils.Infrastructure.Database;
using Tutor.LearningUtils.Infrastructure.Database.Repositories;

namespace Tutor.LearningUtils.Infrastructure;

public static class LearningUtilsStartup
{
    public static IServiceCollection ConfigureLearningUtilitiesModule(this IServiceCollection services)
    {
        // Registers all profiles since it works on the assembly
        services.AddAutoMapper(typeof(FeedbackProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddProxiedScoped<IFeedbackService, FeedbackService>();
        services.AddProxiedScoped<INoteService, NoteService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteDatabaseRepository>();
        services.AddScoped<IFeedbackRepository, FeedbackDatabaseRepository>();

        services.AddScoped<ILearningUtilsUnitOfWork, LearningUtilsUnitOfWork>();
        services.AddDbContext<LearningUtilsContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("learningUtils"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "learningUtils")));
    }
}