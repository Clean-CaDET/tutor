using Tutor.BuildingBlocks.AI.Infrastructure;
using Tutor.BuildingBlocks.Infrastructure.Security;
using Tutor.Courses.Infrastructure;
using Tutor.Elaborations.Infrastructure;
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
            ApiKey = EnvironmentConnection.GetSecret("OPENAI_API_KEY") ?? "TODO",
            ChatModelId = Environment.GetEnvironmentVariable("AI_CHAT_MODEL") ?? "gpt-5.4-mini",
            EmbeddingModelId = Environment.GetEnvironmentVariable("AI_EMBEDDING_MODEL") ?? "text-embedding-3-small"
        });

        services.ConfigureStakeholdersModule();
        services.ConfigureCoursesModule();
        services.ConfigureLearningUtilitiesModule();
        services.ConfigureKnowledgeComponentsModule();
        services.ConfigureLearningTasksModule();
        services.ConfigureElaborationsModule();

        return services;
    }
}