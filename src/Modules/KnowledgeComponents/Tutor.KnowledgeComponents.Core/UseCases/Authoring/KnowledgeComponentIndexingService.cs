using FluentResults;
using Tutor.BuildingBlocks.AI.Core.Embeddings;
using Tutor.BuildingBlocks.AI.Core.VectorStores;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Authoring;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.InstructionalItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;

namespace Tutor.KnowledgeComponents.Core.UseCases.Authoring;

public class KnowledgeComponentIndexingService : IKnowledgeComponentIndexingService
{
    private const int OverlapCharacters = 200;
    private const int ContentPreviewLength = 100;

    private readonly IAccessService _accessService;
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly ITextEmbeddingService _embeddingService;
    private readonly IVectorStore<InstructionalItemEmbeddingMetadata> _vectorStore;
    private readonly IKnowledgeComponentsUnitOfWork _unitOfWork;

    public KnowledgeComponentIndexingService(IAccessService accessService, IKnowledgeComponentRepository kcRepository,
        ITextEmbeddingService embeddingService, IVectorStore<InstructionalItemEmbeddingMetadata> vectorStore,
        IKnowledgeComponentsUnitOfWork unitOfWork)
    {
        _accessService = accessService;
        _kcRepository = kcRepository;
        _embeddingService = embeddingService;
        _vectorStore = vectorStore;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> IndexAsync(int kcId, int instructorId, CancellationToken cancellationToken = default)
    {
        if (!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var kc = _kcRepository.GetWithInstruction(kcId);
        if (kc == null)
            return Result.Fail(FailureCode.NotFound);

        // Delete all existing vectors for this KC to handle removed instructional items
        var deleteFilters = new Dictionary<string, object>
        {
            { nameof(InstructionalItemEmbeddingMetadata.KnowledgeComponentId), kcId }
        };
        var deleteResult = await _vectorStore.DeleteByMetadataAsync(deleteFilters, cancellationToken);
        if (deleteResult.IsFailed)
            return deleteResult.ToResult();

        var textItems = GetOrderedTextItems(kc);
        if (textItems.Count == 0)
            return Result.Ok();

        var textsToEmbed = BuildEmbeddableTexts(textItems);

        var embeddingsResult = await _embeddingService.GenerateEmbeddingsAsync(textsToEmbed, cancellationToken);
        if (embeddingsResult.IsFailed)
            return embeddingsResult.ToResult();

        var embeddings = embeddingsResult.Value;
        var indexedAt = DateTime.UtcNow;

        var records = textItems.Zip(embeddings, (item, embedding) => new VectorRecord<InstructionalItemEmbeddingMetadata>
        {
            Id = $"ii_{item.Id}",
            Embedding = embedding.Vector,
            Metadata = new InstructionalItemEmbeddingMetadata
            {
                UnitId = kc.KnowledgeUnitId,
                KnowledgeComponentId = kcId,
                InstructionalItemId = item.Id,
                Order = item.Order,
                ContentPreview = Truncate(item.Content, ContentPreviewLength),
                IndexedAt = indexedAt
            }
        }).ToList();

        var upsertResult = await _vectorStore.UpsertBatchAsync(records, cancellationToken);
        if (upsertResult.IsFailed)
            return upsertResult;

        kc.IndexingDegree = KcIndexingDegree.Full;
        return _unitOfWork.Save();
    }

    public async Task<Result> DeindexAsync(int kcId, int instructorId, CancellationToken cancellationToken = default)
    {
        if (!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var kc = _kcRepository.GetWithInstruction(kcId);
        if (kc == null) return Result.Fail(FailureCode.NotFound);

        // Delete all vectors for this KC using metadata filter
        var deleteFilters = new Dictionary<string, object>
        {
            { nameof(InstructionalItemEmbeddingMetadata.KnowledgeComponentId), kcId }
        };
        var deleteResult = await _vectorStore.DeleteByMetadataAsync(deleteFilters, cancellationToken);
        if (deleteResult.IsFailed)
            return deleteResult.ToResult();

        kc.IndexingDegree = KcIndexingDegree.None;
        return _unitOfWork.Save();
    }

    private static List<Markdown> GetOrderedTextItems(KnowledgeComponent kc)
    {
        if (kc.InstructionalItems == null) return [];

        return kc.InstructionalItems
            .OfType<Markdown>()
            .OrderBy(item => item.Order)
            .ToList();
    }

    private static List<string> BuildEmbeddableTexts(List<Markdown> items)
    {
        var result = new List<string>(items.Count);

        for (var i = 0; i < items.Count; i++)
        {
            var current = items[i].Content;
            var previousSuffix = i > 0 ? GetSuffix(items[i - 1].Content, OverlapCharacters) : "";
            var nextPrefix = i < items.Count - 1 ? GetPrefix(items[i + 1].Content, OverlapCharacters) : "";

            var embeddableText = string.Join(" ", new[] { previousSuffix, current, nextPrefix }
                .Where(s => !string.IsNullOrWhiteSpace(s)));

            result.Add(embeddableText);
        }

        return result;
    }

    private static string GetSuffix(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;

        return text[^maxLength..];
    }

    private static string GetPrefix(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;

        return text[..maxLength];
    }

    private static string Truncate(string text, int maxLength)
    {
        if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
            return text;

        return text[..maxLength] + "...";
    }
}