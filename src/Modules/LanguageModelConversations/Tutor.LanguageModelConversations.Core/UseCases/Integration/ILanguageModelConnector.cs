using FluentResults;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.UseCases.Integration;

public interface ILanguageModelConnector
{
    Task<Result<ConversationSegment>> TopicConversationAsync(string message, string text, ContextType context, List<LanguageModelMessage>? previousMessages);
    Task<Result<ConversationSegment>> GenerateSimilarAsync(string text, ContextType context);
    Task<Result<ConversationSegment>> SummarizeAsync(string text);
    Task<Result<ConversationSegment>> ExtractKeywordsAsync(string text);
    Task<Result<ConversationSegment>> GenerateQuestionsAsync(string text);
}
