using FluentResults;
using System.Net.Http.Json;
using Tutor.LanguageModelConversations.Infrastructure.Http;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnection;

public static class RequestHandler
{
    private static readonly HttpClient _client = new()
    {
        BaseAddress = new Uri(LanguageModelEndpoints.BaseApi)
    };

    private static readonly string _error = "Connection error";

    internal static async Task<Result<TResponse>> PostAndReadAsync<TResponse, TRequest>(string endpoint, TRequest request)
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
