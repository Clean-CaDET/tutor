using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.BuildingBlocks.AI.Core.Embeddings;
using Tutor.BuildingBlocks.AI.Core.VectorStores;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

namespace Tutor.KnowledgeComponents.Core.UseCases.Learning.Chat;

public class KcChatbotService : IKcChatbotService
{
    private const int TopKChunks = 5;
    private const double MinimumSimilarity = 0.5;

    private readonly IAccessService _accessService;
    private readonly IInstructionalItemRepository _instructionalItemRepository;
    private readonly ITextEmbeddingService _embeddingService;
    private readonly IVectorStore<InstructionalItemEmbeddingMetadata> _vectorStore;
    private readonly IAiChatService _chatService;

    public KcChatbotService(IAccessService accessService, IInstructionalItemRepository instructionalItemRepository,
        ITextEmbeddingService embeddingService, IVectorStore<InstructionalItemEmbeddingMetadata> vectorStore, IAiChatService chatService)
    {
        _accessService = accessService;
        _instructionalItemRepository = instructionalItemRepository;
        _embeddingService = embeddingService;
        _vectorStore = vectorStore;
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> AskQuestionAsync(
        int kcId,
        int learnerId,
        string userMessage,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        if (!_accessService.IsEnrolledInKc(kcId, learnerId))
        {
            yield return "Nemate pristup ovom sadržaju.";
            yield break;
        }

        var embeddingResult = await _embeddingService.GenerateEmbeddingAsync(userMessage, cancellationToken);
        if (embeddingResult.IsFailed)
        {
            yield return "Došlo je do greške prilikom obrade pitanja.";
            yield break;
        }

        var searchQuery = new VectorSearchQuery
        {
            QueryEmbedding = embeddingResult.Value.Vector,
            TopK = TopKChunks,
            MinimumSimilarity = MinimumSimilarity,
            MetadataFilters = new Dictionary<string, object>
            {
                ["KnowledgeComponentId"] = kcId
            }
        };

        var searchResult = await _vectorStore.SearchAsync(searchQuery, cancellationToken);
        if (searchResult.IsFailed)
        {
            yield return "Došlo je do greške prilikom pretrage materijala.";
            yield break;
        }

        var instructionalItemIds = searchResult.Value
            .Select(r => r.Record.Metadata.InstructionalItemId)
            .Distinct()
            .ToList();

        var instructionalItems = _instructionalItemRepository.GetByIds(instructionalItemIds);

        var completionRequest = KcChatPromptFactory.CreateRequest(userMessage, instructionalItems);

        await foreach (var token in _chatService.StreamAsync(completionRequest, cancellationToken))
        {
            yield return token;
        }
    }
}
