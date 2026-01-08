namespace Tutor.BuildingBlocks.AI.Infrastructure;

/// <summary>
/// Configuration for AI services including chat completion and embeddings.
/// </summary>
public record AiServiceConfiguration
{
    public required string ApiKey { get; init; }
    public required string ChatModelId { get; init; }
    public string? EmbeddingModelId { get; init; }
}
