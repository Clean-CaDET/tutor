using Tutor.Courses.Infrastructure;
using Tutor.KnowledgeComponents.Infrastructure;
using Tutor.LearningTasks.Infrastructure;
using Tutor.LearningUtils.Infrastructure;
using Tutor.Stakeholders.Infrastructure;

namespace Tutor.API.Startup;

public static class ModulesConfiguration
{
    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {
        services.ConfigureStakeholdersModule();
        services.ConfigureCoursesModule();
        services.ConfigureLearningUtilitiesModule();
        services.ConfigureKnowledgeComponentsModule();
        services.ConfigureLearningTasksModule();

        return services;
    }
}