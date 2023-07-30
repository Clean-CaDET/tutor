using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Interfaces;
using Tutor.LanguageModelConversations.Core.Domain.RepositoryInterfaces;

namespace Tutor.LanguageModelConversations.Core.UseCases;

public class ConversationService : IConversationService
{
    private readonly IMapper _mapper;
    private readonly IConversationRepository _conversationRepository;
    private readonly ITokenRepository _tokenRepository;
    private readonly ILanguageModelConnector _languageModelConnector;
    private readonly ILanguageModelConversationsUnitOfWork _unitOfWork;

    public ConversationService(IMapper mapper, IConversationRepository conversationRepository, ITokenRepository tokenRepository, ILanguageModelConnector languageModelConnector, ILanguageModelConversationsUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _conversationRepository = conversationRepository;
        _tokenRepository = tokenRepository;
        _languageModelConnector = languageModelConnector;
        _unitOfWork = unitOfWork;
    }

    public Result<ConversationDto> Get(int contextId, int learnerId)
    {
        var result = _conversationRepository.GetByLearnerAndContext(learnerId, contextId);
        return result == null ? Result.Fail(FailureCode.NotFound) : _mapper.Map<ConversationDto>(result);
    }

    public async Task<int> Proba()
    {
        var nesto = await _languageModelConnector.ExtractKeywordsAsync("ovo je lekcija, pera je zec, mika je mis, lena je dinosaurus");
        return 1;
    }

    // TODO: neophodno dodati endpoint u KC modulu koji ce dobavljati listu AI ili AI po id-u

    public async Task<Result<MessageResponse>> SendMessageAsync(MessageRequest message, int learnerId)
    {
        throw new NotImplementedException();
        //var conversation = _conversationRepository.Get(message.ConversationId);
        //if (conversation != null)
        //{
        //    if (conversation.LearnerId != learnerId) return Result.Fail(FailureCode.Forbidden);
        //}
        //else
        //{
        //    // TODO: proveri da li learner sme da pristupi tom contextId (tom KC-u) -> kontaktiraj drugi modul
        //    conversation = new Conversation(message.ConversationId, learnerId, message.ContextId);
        //    _conversationRepository.Create(conversation);
        //}

        //var learnerToken = _tokenRepository.GetByLearner(learnerId);
        //if (learnerToken == null)
        //{
        //    learnerToken = new TokenWallet(learnerId);
        //    _tokenRepository.Create(learnerToken);
        //}
        //if (!learnerToken.ChechCount()) return Result.Fail(FailureCode.InsufficientResources);

        //// TODO: dobavi tekst konteksta kontaktiranjem kc modula (ako je taskId, onda AI, ako nije, onda List<II>)
        //string contextText;
        //if (message.TaskId == null) contextText = "ovo je lekcija, pera je zec";
        //else contextText = "ovo je zadatak, sta je zec";

        //// TODO: sredjivanje koda
        //Result<LmResponse> result;
        //LmResponse lmResponse;
        //switch (message.Type)
        //{
        //    case MessageType.OpenEnded:
        //        if (message.Message == null) return Result.Fail(FailureCode.InvalidArgument);
        //        result = message.TaskId is null ?
        //            await _lmHttpSender.AskAiAboutLectureAsync(contextText, message.Message, conversation.LmMessages)
        //            : await _lmHttpSender.AskAiAboutTaskAsync(contextText, message.Message, conversation.LmMessages);
        //        break;
        //    case MessageType.SimilarTask:
        //        var contextType = message.TaskId is null ? ContextType.Lecture : ContextType.Task;
        //        result = await _lmHttpSender.GenerateSimilarTaskAsync(contextText, contextType);
        //        break;
        //    // TODO: poseban summarization repozitorijum
        //    case MessageType.Summarize:
        //        result = await _lmHttpSender.SummarizeAsync(contextText);
        //        break;
        //    case MessageType.LectureQuestions:
        //        Result<LmQaResponse> qaResult = await _lmHttpSender.GenerateLectureQuestionsAsync(contextText);
        //        result = qaResult.Map(v => v as LmResponse);
        //        break;
        //    case MessageType.Keywords:
        //        Result<LmKeywordResponse> keywordResult = await _lmHttpSender.ExtractKeywordsAsync(contextText);
        //        result = keywordResult.Map(v => v as LmResponse);
        //        break;
        //    default:
        //        return Result.Fail(FailureCode.InvalidArgument);
        //}

        //if (result.IsFailed) return Result.Fail(result.Errors);
        //lmResponse = result.Value;
        //// TODO: previse komplikovana logika za samo preuzimanje broja koji unapred znamo da je 3 uvek (ako se ne menja tutor-ai koji mi kontrolisemo)
        //// proveriti da li je neophodno
        //conversation.AddLmMessages(lmResponse.Messages.TakeLast(3).ToList());
        //learnerToken.ReduceCount(lmResponse.TokenNumber);

        //// TODO: proveriti
        //// Da li je okej da saljemo json serijalizovan objekat na frontend stranu koji on deserijalizuje da bi prikazao poruku
        //// (odgovor moze biti samo string ili lista objekata)
        //// tako se salje kada se salju sve poruke
        //// mozemo tako slati i ovde kada je nova poruka
        //MessageResponse response = _mapper.Map<MessageResponse>(lmResponse);
        //ConversationMessageDto responseMessage = _mapper.Map<ConversationMessageDto>(response);
        //ConversationMessageDto requestMessage = _mapper.Map<ConversationMessageDto>(message);
        //conversation.AddMessages(requestMessage, responseMessage);

        //_conversationRepository.UpdateIfExisting(conversation);
        //_tokenRepository.UpdateIfExisting(learnerToken);
        //var dbResult = _unitOfWork.Save();
        //if (dbResult.IsFailed) return dbResult;

        //return response;
    }
}
