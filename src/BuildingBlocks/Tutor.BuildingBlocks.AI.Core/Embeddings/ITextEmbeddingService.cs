using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.Embeddings;

public interface ITextEmbeddingService
{
    Task<Result<EmbeddingResponse>> GenerateEmbeddingAsync(string text, CancellationToken cancellationToken = default);
    Task<Result<IReadOnlyList<EmbeddingResponse>>> GenerateEmbeddingsAsync(IEnumerable<string> texts, CancellationToken cancellationToken = default);
}