using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.LanguageModelConversations.API.Interfaces;
using Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;
using Tutor.LanguageModelConversations.Core.UseCases;
using Tutor.LanguageModelConversations.Infrastructure.Database;
using Tutor.LanguageModelConversations.Infrastructure.Database.Repositories;
using Tutor.LanguageModelConversations.Core.Mappers;
using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Mappers;
using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector;
using Tutor.BuildingBlocks.Infrastructure.Interceptors;

namespace Tutor.LanguageModelConversations.Infrastructure;

public static class LanguageModelConversationsStartup
{
    public static IServiceCollection ConfigureLanguageModelConversationsModule(this IServiceCollection services)
    {
        SetupMappings(services);
        SetupCore(services);
        SetupInfrastructure(services);
        return services;
    }

    private static void SetupMappings(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ConversationProfile).Assembly);
        services.AddAutoMapper(typeof(LanguageModelProfile).Assembly);
    }

    private static void SetupCore(IServiceCollection services)
    {
        services.AddProxiedScoped<IConversationService, ConversationService>();
    }

    private static void SetupInfrastructure(IServiceCollection services)
    {
        services.AddScoped<IConversationRepository, ConversationDatabaseRepository>();
        services.AddScoped<ITokenWalletRepository, TokenWalletDatabaseRepository>();
        services.AddScoped<ISummarizationRepository, SummarizationDatabaseRepository>();

        services.AddScoped<ILanguageModelConnector, LanguageModelConnector.LanguageModelConnector>();
        services.AddScoped<ILanguageModelConverter, LanguageModelConverter>();

        services.AddScoped<ILanguageModelConversationsUnitOfWork, LanguageModelConversationsUnitOfWork>();
        services.AddDbContext<LanguageModelConversationsContext>(opt =>
            opt.UseNpgsql(CreateConnectionStringFromEnvironment()));
    }

    private static string CreateConnectionStringFromEnvironment()
    {
        var server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
        var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "5432";
        var database = EnvironmentConnection.GetSecret("DATABASE_SCHEMA") ?? "tutor-v4";
        var user = EnvironmentConnection.GetSecret("DATABASE_USERNAME") ?? "postgres";
        var password = EnvironmentConnection.GetSecret("DATABASE_PASSWORD") ?? "admin";
        var integratedSecurity = Environment.GetEnvironmentVariable("DATABASE_INTEGRATED_SECURITY") ?? "false";
        var pooling = Environment.GetEnvironmentVariable("DATABASE_POOLING") ?? "true";

        return
            $"Server={server};Port={port};Database={database};User ID={user};Password={password};Integrated Security={integratedSecurity};Pooling={pooling};";
    }
}
