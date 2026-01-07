using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.Embeddings;

/// <summary>
/// Service for converting text into vector embeddings for semantic similarity comparisons.
/// </summary>
public interface ITextEmbeddingService
{
    Task<Result<EmbeddingResponse>> GenerateEmbeddingAsync(string text, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyList<EmbeddingResponse>>> GenerateEmbeddingsAsync(IEnumerable<string> texts, CancellationToken cancellationToken = default);
}