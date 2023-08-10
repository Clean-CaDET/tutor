using FluentResults;
using Tutor.LanguageModelConversations.API.Dtos;

namespace Tutor.LanguageModelConversations.API.Interfaces;

public interface IConversationService
{
    Result<ConversationDto> GetByContext(int contextGroup, int contextId, int learnerId);
    Task<Result<MessageResponse>> SendMessageAsync(MessageRequest message, int learnerId);
}
