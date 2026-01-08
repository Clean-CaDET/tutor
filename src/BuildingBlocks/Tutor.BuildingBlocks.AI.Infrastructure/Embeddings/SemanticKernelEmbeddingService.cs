using FluentResults;
using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel;
using Tutor.BuildingBlocks.AI.Core.Embeddings;

namespace Tutor.BuildingBlocks.AI.Infrastructure.Embeddings;

/// <summary>
/// Semantic Kernel implementation of text embedding generation.
/// </summary>
public class SemanticKernelEmbeddingService : ITextEmbeddingService
{
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embeddingService;

    public SemanticKernelEmbeddingService(Kernel kernel)
    {
        _embeddingService = kernel.GetRequiredService<IEmbeddingGenerator<string, Embedding<float>>>();
    }

    public async Task<Result<EmbeddingResponse>> GenerateEmbeddingAsync(string text, CancellationToken cancellationToken = default)
    {
        try
        {
            var embeddings = await _embeddingService.GenerateAsync([text], cancellationToken: cancellationToken);
            var embedding = embeddings.First();

            return Result.Ok(new EmbeddingResponse(
                Vector: embedding.Vector,
                TokenCount: 0 // Token count not available in current API
            ));
        }
        catch (Exception ex)
        {
            return Result.Fail<EmbeddingResponse>($"Failed to generate embedding: {ex.Message}");
        }
    }

    public async Task<Result<IReadOnlyList<EmbeddingResponse>>> GenerateEmbeddingsAsync(IEnumerable<string> texts, CancellationToken cancellationToken = default)
    {
        try
        {
            var textList = texts.ToList();
            var embeddings = await _embeddingService.GenerateAsync(textList, cancellationToken: cancellationToken);

            var responses = embeddings.Select(e => new EmbeddingResponse(
                Vector: e.Vector,
                TokenCount: 0 // Token count not available in current API
            )).ToList();

            return Result.Ok<IReadOnlyList<EmbeddingResponse>>(responses);
        }
        catch (Exception ex)
        {
            return Result.Fail<IReadOnlyList<EmbeddingResponse>>($"Failed to generate embeddings: {ex.Message}");
        }
    }
}
