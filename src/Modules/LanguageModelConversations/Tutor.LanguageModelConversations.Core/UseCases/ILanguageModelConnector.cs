using FluentResults;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.UseCases;

public interface ILanguageModelConnector
{
    // TODO: bolje ime koje ima glagol u sebi
    Task<Result<LanguageModelMessage>> TopicConversationAsync(string message, string text, ContextType context, List<LanguageModelMessage>? previousMessages);
    Task<Result<LanguageModelMessage>> GenerateSimilarAsync(string text, ContextType context);
    Task<Result<LanguageModelMessage>> SummarizeAsync(string text);
    Task<Result<List<LanguageModelMessage>>> ExtractKeywordsAsync(string text);
    Task<Result<LanguageModelMessage>> GenerateQuestionsAsync(string text);
}
