namespace Tutor.BuildingBlocks.AI.Core.VectorStores;

/// <summary>
/// A search result with its similarity score.
/// </summary>
public record VectorSearchResult<TMetadata> where TMetadata : class
{
    public required VectorRecord<TMetadata> Record { get; init; }

    /// <summary>
    /// Cosine similarity score (0.0 to 1.0). Higher scores indicate greater semantic similarity.
    /// </summary>
    public required double SimilarityScore { get; init; }
}
