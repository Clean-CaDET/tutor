using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

namespace Tutor.LanguageModelConversations.Core.UseCases.Integration;

public class ConversationProcessor : IConversationProcessor
{
    private readonly ISummarizationRepository _summarizationRepository;
    private readonly ILanguageModelConnector _languageModelConnector;

    public ConversationProcessor(ISummarizationRepository summarizationRepository, ILanguageModelConnector languageModelConnector)
    {
        _summarizationRepository = summarizationRepository;
        _languageModelConnector = languageModelConnector;
    }

    public async Task<Result<ConversationSegment>> ProcessMessageAsync(MessageRequestDto messageRequest, Conversation conversaiton, string contextText)
    {
        if (!Enum.TryParse(messageRequest.MessageType, out MessageType messageType))
            return Result.Fail(FailureCode.InvalidArgument);
        var context = messageRequest.TaskId == null ? ContextType.Lecture : ContextType.Task;

        Result<ConversationSegment> response;
        switch (messageType)
        {
            case MessageType.TopicConversation:
                if (messageRequest.Message == null) return Result.Fail(FailureCode.InvalidArgument);
                response = await _languageModelConnector.TopicConversationAsync(messageRequest.Message, contextText, context, conversaiton.Messages);
                break;
            case MessageType.GenerateSimilar:
                response = await _languageModelConnector.GenerateSimilarAsync(contextText, context);
                break;
            case MessageType.Summarize:
                response = await ProcessSummarizationAsync(messageRequest.ContextId, messageRequest.ContextGroup, contextText);
                break;
            case MessageType.ExtractKeywords:
                response = await _languageModelConnector.ExtractKeywordsAsync(contextText);
                break;
            case MessageType.GenerateQuestions:
                response = await _languageModelConnector.GenerateQuestionsAsync(contextText);
                break;
            default:
                return Result.Fail(FailureCode.InvalidArgument);
        }
        return response;
    }

    private async Task<Result<ConversationSegment>> ProcessSummarizationAsync(int contextId, int contextGroup, string contextText)
    {
        var summarization = _summarizationRepository.GetByContextIdAndGroup(contextId, (ContextGroup)contextGroup);
        if (summarization != null)
            return new ConversationSegment(summarization.Messages, 0);

        var response = await _languageModelConnector.SummarizeAsync(contextText);
        if (response.IsFailed) return response;

        summarization = new Summarization(contextId, (ContextGroup)contextGroup, response.Value.Messages);
        _summarizationRepository.Create(summarization);
        return response;
    }
}
