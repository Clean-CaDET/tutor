using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.BuildingBlocks.Infrastructure.Database;
using Tutor.BuildingBlocks.Infrastructure.Database.EventStore.DefaultEventSerializer;
using Tutor.BuildingBlocks.Infrastructure.Interceptors;
using Tutor.Stakeholders.API.Internal;
using Tutor.Stakeholders.API.Public;
using Tutor.Stakeholders.API.Public.Management;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.Events;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.Core.Mappers;
using Tutor.Stakeholders.Core.UseCases;
using Tutor.Stakeholders.Core.UseCases.Management;
using Tutor.Stakeholders.Infrastructure.Authentication;
using Tutor.Stakeholders.Infrastructure.Database;
using Tutor.Stakeholders.Infrastructure.Database.EventStore;
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
        services.AddProxiedScoped<IInstructorService, InstructorService>();
        services.AddProxiedScoped<IInternalInstructorService, InstructorService>();
        services.AddProxiedScoped<ILearnerService, LearnerService>();
        services.AddProxiedScoped<IInternalLearnerService, LearnerService>();
        services.AddProxiedScoped<IAuthenticationService, AuthenticationService>();
        services.AddProxiedScoped<IWalletService, WalletService>();
        services.AddProxiedScoped<IInternalWalletService, WalletService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped(typeof(ICrudRepository<Instructor>), typeof(CrudDatabaseRepository<Instructor, StakeholdersContext>));
        services.AddScoped<ILearnerRepository, LearnerDatabaseRepository>();
        services.AddScoped<IUserRepository, UserDatabaseRepository>();
        services.AddScoped<IWalletRepository, WalletDatabaseRepository>();
        services.AddScoped(typeof(IEventStore<WalletEvent>), typeof(PostgresStore<WalletEvent>));
        services.AddSingleton<IEventSerializer<WalletEvent>>(new DefaultEventSerializer<WalletEvent>(EventSerializationConfiguration.EventRelatedTypes));

        services.AddScoped<IStakeholdersUnitOfWork, StakeholdersUnitOfWork>();
        services.AddDbContext<StakeholdersContext>(opt =>
            opt.UseNpgsql(DbConnectionStringBuilder.Build("stakeholders"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "stakeholders")));
    }
}