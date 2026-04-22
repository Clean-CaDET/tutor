using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.BuildingBlocks.AI.Core.Embeddings;
using Tutor.BuildingBlocks.AI.Core.VectorStores;
using Tutor.BuildingBlocks.AI.Infrastructure.Conversations;
using Tutor.BuildingBlocks.AI.Infrastructure.Embeddings;
using Tutor.BuildingBlocks.AI.Infrastructure.VectorStores;

namespace Tutor.BuildingBlocks.AI.Infrastructure;

public static class AiServiceExtensions
{
    /// <summary>
    /// Registers AI services including chat completion and optionally text embeddings.
    /// </summary>
    public static IServiceCollection AddAIServices(this IServiceCollection services, AiServiceConfiguration configuration)
    {
        if (string.IsNullOrWhiteSpace(configuration.ApiKey))
            return services;

        var kernelBuilder = Kernel.CreateBuilder();

        kernelBuilder.AddOpenAIChatCompletion(modelId: configuration.ChatModelId, apiKey: configuration.ApiKey);

        if (!string.IsNullOrWhiteSpace(configuration.EmbeddingModelId))
        {
            kernelBuilder.AddOpenAIEmbeddingGenerator(modelId: configuration.EmbeddingModelId, apiKey: configuration.ApiKey);
        }

        var kernel = kernelBuilder.Build();
        services.AddSingleton(kernel);
        services.AddScoped<ITurnUsageTracker, TurnUsageTracker>();
        services.AddScoped<SemanticKernelChatService>();
        services.AddScoped<IAiChatService>(sp => new LoggingAiChatServiceDecorator(
            sp.GetRequiredService<SemanticKernelChatService>(),
            sp.GetRequiredService<ILogger<LoggingAiChatServiceDecorator>>()));

        if (!string.IsNullOrWhiteSpace(configuration.EmbeddingModelId))
        {
            services.AddSingleton<ITextEmbeddingService, SemanticKernelEmbeddingService>();
        }

        return services;
    }

    /// <summary>
    /// Registers a pgvector-based vector store for a specific metadata type.
    /// Each module should call this to register their own vector store instance.
    /// </summary>
    public static IServiceCollection AddVectorStore<TMetadata>(
        this IServiceCollection services,
        VectorStoreConfiguration configuration) where TMetadata : class
    {
        services.AddSingleton<IVectorStore<TMetadata>>(sp => new PgVectorStore<TMetadata>(configuration));
        return services;
    }
}
