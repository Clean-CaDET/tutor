using FluentResults;
using System.Net.Http.Json;
using Tutor.LmConversations.API.Dtos;
using Tutor.LmConversations.API.Dtos.Integration.Response;
using Tutor.LmConversations.Core.UseCases;
using Tutor.LmConversations.Infrastructure.Http.Dtos;

namespace Tutor.LmConversations.Infrastructure.Http;

public class LmHttpSender : ILmHttpSender
{
    private static readonly HttpClient _client = new()
    {
        BaseAddress = new Uri(LmEndpoints.BaseApi)
    };

    private static readonly string _error = "Connection error";

    public async Task<Result<LmResponse>> AskAiAboutLectureAsync(string lectureText, string newMessage, List<LmMessageDto>? previousMessages)
    {
        var request = new LmOpenEndedLectureRequest()
        {
            LectureText = lectureText,
            NewMessage = newMessage,
            PreviousMessages = previousMessages
        };
        return await PostAndReadAsync<LmResponse, LmOpenEndedLectureRequest>(LmEndpoints.AskAiAboutLecture, request);
    }

    public async Task<Result<LmResponse>> AskAiAboutTaskAsync(string taskText, string newMessage, List<LmMessageDto>? previousMessages)
    {
        var request = new LmOpenEndedTaskRequest()
        {
            TaskText = taskText,
            NewMessage = newMessage,
            PreviousMessages = previousMessages
        };
        return await PostAndReadAsync<LmResponse, LmOpenEndedTaskRequest>(LmEndpoints.AskAiAboutTask, request);
    }

    public async Task<Result<LmResponse>> SummarizeAsync(string lectureText)
    {
        var request = new LmLectureActionRequest()
        {
            LectureText = lectureText
        };
        return await PostAndReadAsync<LmResponse, LmLectureActionRequest>(LmEndpoints.Summarize, request);
    }

    public async Task<Result<LmKeywordResponse>> ExtractKeywordsAsync(string lectureText)
    {
        var request = new LmLectureActionRequest()
        {
            LectureText = lectureText
        };
        return await PostAndReadAsync<LmKeywordResponse, LmLectureActionRequest>(LmEndpoints.ExtractKeywords, request);
    }

    public async Task<Result<LmQaResponse>> GenerateLectureQuestionsAsync(string lectureText)
    {
        var request = new LmLectureActionRequest()
        {
            LectureText = lectureText
        };
        return await PostAndReadAsync<LmQaResponse, LmLectureActionRequest>(LmEndpoints.GenerateLectureQuestions, request);
    }

    public async Task<Result<LmResponse>> GenerateSimilarTaskAsync(string text, ContextType context)
    {
        var request = new LmActionRequest()
        {
            Text = text,
            Context = context
        };
        return await PostAndReadAsync<LmResponse, LmActionRequest>(LmEndpoints.GenerateSimilarTask, request);
    }

    private static async Task<Result<TResponse>> PostAndReadAsync<TResponse, TRequest>(string endpoint, TRequest request)
    {
        try
        {
            var response = await _client.PostAsJsonAsync(endpoint, request);
            response.EnsureSuccessStatusCode();
            var lmResponse = await response.Content.ReadFromJsonAsync<TResponse>();
            return lmResponse == null ? Result.Fail(_error) : lmResponse;
        }
        catch (HttpRequestException)
        {
            return Result.Fail(_error);
        }
    }

}
