using Tutor.Stakeholders.Infrastructure;

namespace Tutor.API.Startup;

public static class ModulesConfiguration
{
    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        services.ConfigureStakeholdersModule();

        return services;
    }
}