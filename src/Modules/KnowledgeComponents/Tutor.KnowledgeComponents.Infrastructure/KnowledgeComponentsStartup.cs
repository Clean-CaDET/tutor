using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.KnowledgeComponents.Core.UseCases;
using Tutor.KnowledgeComponents.Infrastructure.Database;

namespace Tutor.KnowledgeComponents.Infrastructure;

public static class KnowledgeComponentsStartup
{
    public static IServiceCollection ConfigureKnowledgeComponentsModule(this IServiceCollection services)
    {
        //services.AddAutoMapper(typeof(StakeholdersProfile).Assembly);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }
    
    private static void SetupCore(IServiceCollection services)
    {

    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
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