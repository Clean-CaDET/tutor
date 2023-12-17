using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Interfaces;
using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;
using Tutor.LanguageModelConversations.Core.UseCases.Integration;

namespace Tutor.LanguageModelConversations.Core.UseCases;

public class ConversationService : IConversationService
{
    private readonly IMapper _mapper;
    private readonly IConversationRepository _conversationRepository;
    private readonly ITokenWalletRepository _tokenWalletRepository;
    private readonly IConversationProcessor _conversationProcessor;
    private readonly IContextSelectionService _contextSelectionService;
    private readonly ILanguageModelConversationsUnitOfWork _unitOfWork;

    public ConversationService(IMapper mapper, IConversationRepository conversationRepository, ITokenWalletRepository tokenWalletRepository, IConversationProcessor conversationProcessor, 
        IContextSelectionService contextSelectionService, ILanguageModelConversationsUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _conversationRepository = conversationRepository;
        _tokenWalletRepository = tokenWalletRepository;
        _conversationProcessor = conversationProcessor;
        _contextSelectionService = contextSelectionService;
        _unitOfWork = unitOfWork;
    }

    public Result<ConversationDto> GetByContext(int contextGroup, int contextId, int learnerId)
    {
        var result = _conversationRepository.GetByLearnerContextIdAndGroup(learnerId, contextId, (ContextGroup)contextGroup);
        return result == null ? Result.Fail(FailureCode.NotFound) : _mapper.Map<ConversationDto>(result);
    }

    public async Task<Result<MessageResponseDto>> SendMessageAsync(MessageRequestDto message, int learnerId)
    {
        var contextTextResult = _contextSelectionService.GetContextText(message.ContextGroup, message.ContextId, message.TaskId, learnerId);
        if (contextTextResult.IsFailed) return Result.Fail(contextTextResult.Errors);

        var tokenResult = GetOrCreateTokenWallet(message.CourseId, learnerId);
        if (tokenResult.IsFailed) return Result.Fail(tokenResult.Errors);
        var tokenWallet = tokenResult.Value;

        if (!tokenWallet.CheckAmount()) return Result.Fail(FailureCode.InsufficientFunds);

        var conversationResult = GetOrCreateConversation(message.ConversationId, message.ContextGroup, message.ContextId, learnerId);
        if (conversationResult.IsFailed) return Result.Fail(conversationResult.Errors);
        var conversation = conversationResult.Value;

        var response = await _conversationProcessor.ProcessMessageAsync(message, conversation, contextTextResult.Value);
        if (response.IsFailed) return Result.Fail(response.Errors);

        conversation.AddMessages(response.Value.Messages);
        tokenWallet.ReduceAmount(response.Value.TokensUsed);

        _conversationRepository.UpdateIfExisting(conversation);
        _tokenWalletRepository.UpdateIfExisting(tokenWallet);
        var dbResult = _unitOfWork.Save();
        if (dbResult.IsFailed) return dbResult;

        return _mapper.Map<MessageResponseDto>(conversation.Messages.Last());
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
}
