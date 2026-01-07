namespace Tutor.BuildingBlocks.AI.Core.Embeddings;

/// <summary>
/// Vector representation of text produced by an embedding model.
/// </summary>
public record EmbeddingResponse(ReadOnlyMemory<float> Vector, int TokenCount);