using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.VectorStores;

/// <summary>
/// Storage and retrieval operations for vector embeddings. Used for semantic search and RAG.
/// </summary>
public interface IVectorStore<TMetadata> where TMetadata : class
{
    Task<Result> UpsertAsync(VectorRecord<TMetadata> record, CancellationToken cancellationToken = default);
    Task<Result> UpsertBatchAsync(IEnumerable<VectorRecord<TMetadata>> records, CancellationToken cancellationToken = default);

    Task<Result<VectorRecord<TMetadata>>> GetByIdAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds records most semantically similar to the query embedding, ordered by similarity score (highest first).
    /// </summary>
    Task<Result<IReadOnlyList<VectorSearchResult<TMetadata>>>> SearchAsync(VectorSearchQuery query, CancellationToken cancellationToken = default);

    Task<Result> DeleteAsync(string id, CancellationToken cancellationToken = default);
    Task<Result> DeleteBatchAsync(IEnumerable<string> ids, CancellationToken cancellationToken = default);
}
