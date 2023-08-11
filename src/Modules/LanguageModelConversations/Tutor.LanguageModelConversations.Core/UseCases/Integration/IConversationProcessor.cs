using FluentResults;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.UseCases.Integration;

public interface IConversationProcessor
{
    Task<Result<ConversationSegment>> ProcessMessageAsync(MessageRequestDto messageRequest, Conversation conversaiton, string contextText);
}
