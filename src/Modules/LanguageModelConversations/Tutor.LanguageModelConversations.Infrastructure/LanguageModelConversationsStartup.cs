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
using Tutor.BuildingBlocks.Infrastructure.Database;

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
            opt.UseNpgsql(DbConnectionStringBuilder.Build("languageModelConversations"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "languageModelConversations")));
    }
}
