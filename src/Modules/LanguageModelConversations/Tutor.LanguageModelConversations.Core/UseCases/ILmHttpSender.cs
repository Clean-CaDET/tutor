using FluentResults;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Dtos.Integration.Response;

namespace Tutor.LanguageModelConversations.Core.UseCases;

// ILmConnection -> preimenovati
public interface ILmHttpSender
{
    Task<Result<LmResponse>> AskAiAboutLectureAsync(string lectureText, string newMessage, List<LmMessageDto>? previousMessages);
    Task<Result<LmResponse>> AskAiAboutTaskAsync(string taskText, string newMessage, List<LmMessageDto>? previousMessages);
    Task<Result<LmResponse>> SummarizeAsync(string lectureText);
    Task<Result<LmKeywordResponse>> ExtractKeywordsAsync(string lectureText);
    Task<Result<LmQaResponse>> GenerateLectureQuestionsAsync(string lectureText);
    Task<Result<LmResponse>> GenerateSimilarTaskAsync(string text, ContextType context);
}
