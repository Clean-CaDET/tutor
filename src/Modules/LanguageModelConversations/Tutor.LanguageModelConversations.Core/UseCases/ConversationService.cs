using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Public.Learning;
using Tutor.KnowledgeComponents.API.Public.Learning.Assessment;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Interfaces;
using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

namespace Tutor.LanguageModelConversations.Core.UseCases;

public class ConversationService : IConversationService
{
    private readonly IMapper _mapper;
    private readonly IConversationRepository _conversationRepository;
    private readonly ITokenWalletRepository _tokenWalletRepository;
    private readonly ISummarizationRepository _summarizationRepository;
    private readonly ILanguageModelConnector _languageModelConnector;
    private readonly ILanguageModelConverter _languageModelConverter;
    private readonly IInstructionService _instructionSelector;
    private readonly ISelectionService _taskSelector;
    private readonly ILanguageModelConversationsUnitOfWork _unitOfWork;

    public ConversationService(IMapper mapper, IConversationRepository conversationRepository, ITokenWalletRepository tokenWalletRepository, ISummarizationRepository summarizationRepository, 
        ILanguageModelConnector languageModelConnector, ILanguageModelConverter languageModelConverter, IInstructionService instructionSelector, ISelectionService taskSelector, ILanguageModelConversationsUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _conversationRepository = conversationRepository;
        _tokenWalletRepository = tokenWalletRepository;
        _summarizationRepository = summarizationRepository;
        _languageModelConnector = languageModelConnector;
        _languageModelConverter = languageModelConverter;
        _instructionSelector = instructionSelector;
        _taskSelector = taskSelector;
        _unitOfWork = unitOfWork;
    }

    public Result<ConversationDto> Get(int contextId, int learnerId)
    {
        var result = _conversationRepository.GetByLearnerAndContext(learnerId, contextId);
        return result == null ? Result.Fail(FailureCode.NotFound) : _mapper.Map<ConversationDto>(result);
    }

    public async Task<Result<MessageResponse>> SendMessageAsync(MessageRequest message, int learnerId)
    {
        var contextTextResult = GetContextText(message.ContextGroup, message.ContextId, message.TaskId, learnerId);
        if (contextTextResult.IsFailed) return Result.Fail(contextTextResult.Errors);

        var tokenResult = GetOrCreateTokenWallet(message.CourseId, learnerId);
        if (tokenResult.IsFailed) return Result.Fail(tokenResult.Errors);
        var tokenWallet = tokenResult.Value;

        if (!tokenWallet.CheckAmount()) return Result.Fail(FailureCode.InsufficientResources);

        var conversationResult = GetOrCreateConversation(message.ConversationId, message.ContextGroup, message.ContextId, learnerId);
        if (conversationResult.IsFailed) return Result.Fail(conversationResult.Errors);
        var conversation = conversationResult.Value;

        var response = await ProcessMessageAsync(message, conversation, contextTextResult.Value);
        if (response.IsFailed) return Result.Fail(response.Errors);

        conversation.AddMessages(response.Value.Messages);
        tokenWallet.ReduceAmount(response.Value.TokensUsed);

        _conversationRepository.UpdateIfExisting(conversation);
        _tokenWalletRepository.UpdateIfExisting(tokenWallet);
        var dbResult = _unitOfWork.Save();
        if (dbResult.IsFailed) return dbResult;

        return _mapper.Map<MessageResponse>(conversation.Messages.Last());
    }

    private Result<Conversation> GetOrCreateConversation(int conversationId, int contextGroup, int contextId, int learnerId)
    {
        var conversation = _conversationRepository.Get(conversationId);
        if (conversation != null)
        {
            if (conversation.LearnerId != learnerId)
                return Result.Fail(FailureCode.Forbidden);
        }
        else
        {
            conversation = new Conversation(conversationId, learnerId, (ContextGroup)contextGroup, contextId);
            _conversationRepository.Create(conversation);
        }
        return conversation;
    }

    private Result<TokenWallet> GetOrCreateTokenWallet(int courseId, int learnerId)
    {
        var tokenWallet = _tokenWalletRepository.GetByLearnerAndCourse(learnerId, courseId);
        if (tokenWallet == null)
        {
            tokenWallet = new TokenWallet(learnerId, courseId);
            _tokenWalletRepository.Create(tokenWallet);
        }
        return tokenWallet;
    }

    private Result<string> GetContextText(int contextGroup, int contextId, int? taskId, int learnerId)
    {
        if ((ContextGroup)contextGroup != ContextGroup.KnowledgeComponent)
            // Expand when LearningTasks are added
            return Result.Fail(FailureCode.InvalidArgument);

        string contextText;
        if (taskId == null)
        {
            var instructionResult = _instructionSelector.GetByKc(contextId, learnerId);
            if (instructionResult.IsFailed) return Result.Fail(instructionResult.Errors);

            contextText = _languageModelConverter.ConvertInstructionalItems(instructionResult.Value);
        }
        else
        {
            var assessmentResult = _taskSelector.SelectAssessmentItemById(contextId, (int)taskId, learnerId);
            if (assessmentResult.IsFailed) return Result.Fail(assessmentResult.Errors);

            contextText = _languageModelConverter.ConvertAssessmentItem(assessmentResult.Value);
        }
        return contextText;
    }

    private async Task<Result<ConversationSegment>> ProcessMessageAsync(MessageRequest messageRequest, Conversation conversaiton, string contextText)
    {
        if (!Enum.TryParse(messageRequest.MessageType, out MessageType messageType))
            return Result.Fail(FailureCode.InvalidArgument);
        var context = messageRequest.TaskId == null ? ContextType.Lecture : ContextType.Task;

        Result<ConversationSegment> response;
        switch (messageType)
        {
            case MessageType.TopicConversation:
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
