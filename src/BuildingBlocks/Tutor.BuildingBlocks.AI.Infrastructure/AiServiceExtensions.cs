using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.BuildingBlocks.AI.Infrastructure.Conversations;

namespace Tutor.BuildingBlocks.AI.Infrastructure;

public static class AiServiceExtensions
{
    public static IServiceCollection AddAIServices(this IServiceCollection services, AiServiceConfiguration configuration)
    {
        var kernelBuilder = Kernel.CreateBuilder();

        kernelBuilder.AddOpenAIChatCompletion(modelId: configuration.ChatModelId, apiKey: configuration.ApiKey);

        var kernel = kernelBuilder.Build();
        services.AddSingleton(kernel);
        services.AddSingleton<IAiChatService, SemanticKernelChatService>();

        return services;
    }
}
