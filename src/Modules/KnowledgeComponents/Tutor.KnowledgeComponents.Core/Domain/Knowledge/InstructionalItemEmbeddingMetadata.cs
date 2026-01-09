namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge;

public class InstructionalItemEmbeddingMetadata
{
    public required int UnitId { get; init; }
    public required int KnowledgeComponentId { get; init; }
    public required int InstructionalItemId { get; init; }
    public required int Order { get; init; }
    public required string ContentPreview { get; init; }
    public required DateTime IndexedAt { get; init; }
}
