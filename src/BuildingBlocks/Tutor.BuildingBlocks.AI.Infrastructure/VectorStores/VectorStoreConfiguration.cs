namespace Tutor.BuildingBlocks.AI.Infrastructure.VectorStores;

/// <summary>
/// Configuration for pgvector-based vector storage.
/// </summary>
public record VectorStoreConfiguration
{
    public required string ConnectionString { get; init; }
    public required string TableName { get; init; }
    public required int VectorDimensions { get; init; }
}
