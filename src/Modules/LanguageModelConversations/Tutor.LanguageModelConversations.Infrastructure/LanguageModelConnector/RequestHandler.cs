using FluentResults;
using System.Net.Http.Json;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector;

public static class RequestHandler
{
    private static readonly HttpClient _client = new()
    {
        BaseAddress = new Uri(LanguageModelConsts.BaseApi)
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
