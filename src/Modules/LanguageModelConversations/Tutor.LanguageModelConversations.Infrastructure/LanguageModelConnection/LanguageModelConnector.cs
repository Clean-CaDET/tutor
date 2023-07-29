using FluentResults;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.Core.UseCases;
using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection;
using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Request;
using Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection.Response;

namespace Tutor.LanguageModelConversations.Infrastructure.Http;

public class LanguageModelConnector : ILanguageModelConnector
{
    public async Task<Result<LmDto>> AskAiAboutLectureAsync(string lectureText, string newMessage, List<LmMessageDto>? previousMessages)
    {
        var request = new LmOpenEndedLectureDto()
        {
            LectureText = lectureText,
            NewMessage = newMessage,
            PreviousMessages = previousMessages
        };
        return await RequestHandler.PostAndReadAsync<LmDto, LmOpenEndedLectureDto>(LanguageModelEndpoints.AskAiAboutLecture, request);
    }

    public async Task<Result<LmDto>> AskAiAboutTaskAsync(string taskText, string newMessage, List<LmMessageDto>? previousMessages)
    {
        var request = new LmOpenEndedTaskDto()
        {
            TaskText = taskText,
            NewMessage = newMessage,
            PreviousMessages = previousMessages
        };
        return await RequestHandler.PostAndReadAsync<LmDto, LmOpenEndedTaskDto>(LanguageModelEndpoints.AskAiAboutTask, request);
    }

    public async Task<Result<LmDto>> SummarizeAsync(string lectureText)
    {
        var request = new LmLectureActionDto()
        {
            LectureText = lectureText
        };
        return await RequestHandler.PostAndReadAsync<LmDto, LmLectureActionDto>(LanguageModelEndpoints.Summarize, request);
    }

    public async Task<Result<LmKeywordDto>> ExtractKeywordsAsync(string lectureText)
    {
        var request = new LmLectureActionDto()
        {
            LectureText = lectureText
        };
        return await RequestHandler.PostAndReadAsync<LmKeywordDto, LmLectureActionDto>(LanguageModelEndpoints.ExtractKeywords, request);
    }

    public async Task<Result<LmQaDto>> GenerateLectureQuestionsAsync(string lectureText)
    {
        var request = new LmLectureActionDto()
        {
            LectureText = lectureText
        };
        return await RequestHandler.PostAndReadAsync<LmQaDto, LmLectureActionDto>(LanguageModelEndpoints.GenerateLectureQuestions, request);
    }

    public async Task<Result<LmDto>> GenerateSimilarTaskAsync(string text, ContextType context)
    {
        var request = new LmActionDto()
        {
            Text = text,
            Context = context
        };
        return await RequestHandler.PostAndReadAsync<LmDto, LmActionDto>(LanguageModelEndpoints.GenerateSimilarTask, request);
    }

}
