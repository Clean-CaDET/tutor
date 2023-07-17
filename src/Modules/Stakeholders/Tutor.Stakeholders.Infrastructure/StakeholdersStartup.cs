using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.Stakeholders.API.Interfaces;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.Core.Mappers;
using Tutor.Stakeholders.Core.UseCases;
using Tutor.Stakeholders.Core.UseCases.Management;
using Tutor.Stakeholders.Infrastructure.Authentication;
using Tutor.Stakeholders.Infrastructure.Database;
using Tutor.Stakeholders.Infrastructure.Database.Repositories;

namespace Tutor.Stakeholders.Infrastructure;

public static class StakeholdersStartup
{
    public static IServiceCollection ConfigureStakeholdersModule(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(StakeholderProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }
    
    private static void SetupCore(IServiceCollection services)
    {
        services.AddScoped<IInstructorService, InstructorService>();
        services.AddScoped<ILearnerService, LearnerService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<Instructor>), typeof(CrudDatabaseRepository<Instructor, StakeholdersContext>));
        services.AddScoped<ILearnerRepository, LearnerDatabaseRepository>();
        services.AddScoped<IUserRepository, UserDatabaseRepository>();

        services.AddScoped<IStakeholdersUnitOfWork, StakeholdersUnitOfWork>();
        services.AddDbContext<StakeholdersContext>(opt =>
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