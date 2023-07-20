using Tutor.LearningUtils.Infrastructure;
using Tutor.Stakeholders.Infrastructure;

namespace Tutor.API.Startup;

public static class ModulesConfiguration
{
    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        services.ConfigureStakeholdersModule();
        services.ConfigureLearningUtilitiesModule();

        return services;
    }
}