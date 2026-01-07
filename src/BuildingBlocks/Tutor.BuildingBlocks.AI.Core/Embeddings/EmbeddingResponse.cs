namespace Tutor.BuildingBlocks.AI.Core.Embeddings;

public record EmbeddingResponse(ReadOnlyMemory<float> Vector, int TokenCount);