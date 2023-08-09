using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
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
    private readonly ILanguageModelConnector _languageModelConnector;
    private readonly ILanguageModelConversationsUnitOfWork _unitOfWork;

    public ConversationService(IMapper mapper, IConversationRepository conversationRepository, ITokenWalletRepository tokenWalletRepository, ILanguageModelConnector languageModelConnector, ILanguageModelConversationsUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _conversationRepository = conversationRepository;
        _tokenWalletRepository = tokenWalletRepository;
        _languageModelConnector = languageModelConnector;
        _unitOfWork = unitOfWork;
    }

    public Result<ConversationDto> Get(int contextId, int learnerId)
    {
        var result = _conversationRepository.GetByLearnerAndContext(learnerId, contextId);
        return result == null ? Result.Fail(FailureCode.NotFound) : _mapper.Map<ConversationDto>(result);
    }

    // TODO: neophodno dodati endpoint u KC modulu koji ce dobavljati listu AI ili AI po id-u

    public async Task<Result<MessageResponse>> SendMessageAsync(MessageRequest message, int learnerId)
    {
        var conversationResult = GetOrCreateConversation(message, learnerId);
        if (conversationResult.IsFailed) return Result.Fail(conversationResult.Errors);
        var conversation = conversationResult.Value;

        var tokenResult = GetOrCreateTokenWallet(message.CourseId, learnerId);
        if (tokenResult.IsFailed) return Result.Fail(tokenResult.Errors);
        var tokenWallet = tokenResult.Value;

        if (!tokenWallet.CheckAmount()) return Result.Fail(FailureCode.InsufficientResources);

        // TODO: dobavi tekst konteksta kontaktiranjem kc modula (ako je taskId, onda AI, ako nije, onda List<II>)
        string contextText;
        if (message.TaskId == null) contextText = "ovo je lekcija, pera je zec";
        else contextText = "ovo je zadatak, sta je zec";

        var response = await ProcessMessageAsync(message, conversation, contextText);
        if (response.IsFailed) return Result.Fail(response.Errors);

        conversation.AddMessages(response.Value.Messages);
        tokenWallet.ReduceAmount(response.Value.TokensUsed);

        _conversationRepository.UpdateIfExisting(conversation);
        _tokenWalletRepository.UpdateIfExisting(tokenWallet);
        var dbResult = _unitOfWork.Save();
        if (dbResult.IsFailed) return dbResult;

        return _mapper.Map<MessageResponse>(conversation.Messages.Last());
    }

    private Result<Conversation> GetOrCreateConversation(MessageRequest message, int learnerId)
    {
        var conversation = _conversationRepository.Get(message.ConversationId);
        if (conversation != null)
        {
            if (conversation.LearnerId != learnerId)
                return Result.Fail(FailureCode.Forbidden);
        }
        else
        {
            // TODO: proveri da li learner sme da pristupi tom contextId (tom KC-u) -> kontaktiraj drugi modul
            conversation = new Conversation(message.ConversationId, learnerId, message.ContextId);
            _conversationRepository.Create(conversation);
        }
        return conversation;
    }

    private Result<TokenWallet> GetOrCreateTokenWallet(int courseId, int learnerId)
    {
        var tokenWallet = _tokenWalletRepository.GetByLearner(learnerId);
        if (tokenWallet == null)
        {
            // TODO: proveriti da li learner sme da pristupi course
            tokenWallet = new TokenWallet(learnerId, courseId);
            _tokenWalletRepository.Create(tokenWallet);
        }
        return tokenWallet;
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
                // TODO: uprostiti ako je moguce
                // samo njemu treba ucitana konverzacija u tom momentu, ostalima ne treba
                response = await _languageModelConnector.TopicConversationAsync(messageRequest.Message, contextText, context, conversaiton.Messages);
                break;
            case MessageType.GenerateSimilar:
                response = await _languageModelConnector.GenerateSimilarAsync(contextText, context);
                break;
            case MessageType.Summarize:
                // TODO: poseban repo za sumarizaciju
                response = await _languageModelConnector.SummarizeAsync(contextText);
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
}
