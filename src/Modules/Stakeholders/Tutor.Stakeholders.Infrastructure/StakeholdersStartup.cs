using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.Stakeholders.API.Internal;
using Tutor.Stakeholders.API.Public;
using Tutor.Stakeholders.API.Public.Management;
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
        services.AddScoped<IInternalInstructorService, InstructorService>();
        services.AddScoped<ILearnerService, LearnerService>();
        services.AddScoped<IInternalLearnerService, LearnerService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<Instructor>), typeof(CrudDatabaseRepository<Instructor, StakeholdersContext>));
        services.AddScoped<ILearnerRepository, LearnerDatabaseRepository>();
        services.AddScoped<IUserRepository, UserDatabaseRepository>();

        services.AddScoped<IStakeholdersUnitOfWork, StakeholdersUnitOfWork>();
        services.AddDbContext<StakeholdersContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("stakeholders"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "stakeholders")));
    }
}