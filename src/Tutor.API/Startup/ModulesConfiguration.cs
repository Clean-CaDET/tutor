using Tutor.BuildingBlocks.AI.Infrastructure;
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
        services.AddAIServices(new AiServiceConfiguration
        {
            ApiKey = "TODO",
            ChatModelId = "gpt-4.1-mini",
            EmbeddingModelId = "text-embedding-3-small"
        }); // TODO: Move configuration to environment variables

        services.ConfigureStakeholdersModule();
        services.ConfigureCoursesModule();
        services.ConfigureLearningUtilitiesModule();
        services.ConfigureKnowledgeComponentsModule();
        services.ConfigureLearningTasksModule();

        return services;
    }
}