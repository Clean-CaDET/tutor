using FluentResults;
using Tutor.LmConversations.API.Dtos;

namespace Tutor.LmConversations.API.Interfaces;

public interface IConversationService
{
    Result<ConversationDto> Get(int contextId, int learnerId);
    Task<Result<MessageResponse>> SendMessage(MessageRequest message, int learnerId);
}
