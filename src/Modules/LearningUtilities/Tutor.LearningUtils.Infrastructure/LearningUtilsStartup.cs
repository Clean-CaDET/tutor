using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.LearningUtils.API.Interfaces;
using Tutor.LearningUtils.Core.Domain;
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
        services.AddAutoMapper(typeof(FeedbackProfile).Assembly);
        services.AddAutoMapper(typeof(NoteProfile).Assembly);
        services.AddAutoMapper(typeof(RatingProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IFeedbackService, FeedbackService>();
        services.AddScoped<INoteService, NoteService>();
        services.AddScoped<IRatingService, RatingService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<Note>), typeof(CrudDatabaseRepository<Note, LearningUtilsContext>));
        services.AddScoped<INoteRepository, NoteDatabaseRepository>();
        services.AddScoped<IFeedbackRepository, FeedbackDatabaseRepository>();
        services.AddScoped<IRatingRepository, RatingDatabaseRepository>();

        services.AddScoped<ILearningUtilsUnitOfWork, LearningUtilsUnitOfWork>();
        services.AddDbContext<LearningUtilsContext>(opt =>
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