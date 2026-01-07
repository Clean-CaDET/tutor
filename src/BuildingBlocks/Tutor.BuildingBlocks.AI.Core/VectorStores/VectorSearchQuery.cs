namespace Tutor.BuildingBlocks.AI.Core.VectorStores;

/// <summary>
/// Parameters for vector similarity search.
/// </summary>
public record VectorSearchQuery
{
    public required ReadOnlyMemory<float> QueryEmbedding { get; init; }
    public int TopK { get; init; } = 10;

    /// <summary>
    /// Cosine similarity threshold (0.0 to 1.0). Scores above 0.7 typically indicate strong relevance.
    /// </summary>
    public double MinimumSimilarity { get; init; } = 0.0;

    /// <summary>
    /// Optional filters applied to metadata (e.g., {"CourseId": "course-123"}).
    /// </summary>
    public IDictionary<string, object>? MetadataFilters { get; init; }
}
