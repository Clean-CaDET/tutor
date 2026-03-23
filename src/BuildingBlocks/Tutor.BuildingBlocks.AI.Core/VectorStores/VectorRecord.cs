namespace Tutor.BuildingBlocks.AI.Core.VectorStores;

/// <summary>
/// A vector embedding with associated metadata for semantic search.
/// </summary>
public record VectorRecord<TMetadata> where TMetadata : class
{
    public required string Id { get; init; }
    public required ReadOnlyMemory<float> Embedding { get; init; }
    public required TMetadata Metadata { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
