using System.Text.Json;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Core.Agents;

/// <summary>
/// Base class for agents that consume a full (non-streamed) LLM completion, optionally parsing JSON into a typed result.
/// Handles the retry loop, deserialization, and logging so derived agents only define their DTO and mapping rules.
/// </summary>
public abstract class StructuredAgent
{
    private const int MaxAttempts = 2;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    protected IAiChatService ChatService { get; }
    private readonly ILogger _logger;

    protected StructuredAgent(IAiChatService chatService, ILogger logger)
    {
        ChatService = chatService;
        _logger = logger;
    }

    /// <summary>
    /// Runs the request, deserializes the response as <typeparamref name="TResponse"/>, and maps/validates it
    /// through <paramref name="validateAndMap"/>. Retries on LLM failure, malformed JSON, or a failed validation Result.
    /// </summary>
    protected async Task<Result<TResult>> CompleteJsonAsync<TResponse, TResult>(string systemPrompt, string userMessage,
        int maxTokens, double temperature, Func<TResponse, Result<TResult>> validateAndMap,
        string failureMessage, CancellationToken ct) where TResponse : class
    {
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens, temperature)
            with { Metadata = new Dictionary<string, object> { ["AgentName"] = GetType().Name } };

        for (var attempt = 0; attempt < MaxAttempts; attempt++)
        {
            var completion = await ChatService.CompleteAsync(request, ct);
            if (completion.IsFailed) continue;

            if (ShouldSkipRetry(completion.Value.FinishReason))
            {
                _logger.LogWarning(
                    "{Agent} skipping retry due to deterministic finish reason '{FinishReason}'.",
                    GetType().Name, completion.Value.FinishReason);
                break;
            }

            var parsed = TryDeserialize<TResponse>(completion.Value.Content);
            if (parsed is null) continue;

            var mapped = validateAndMap(parsed);
            if (mapped.IsSuccess) return mapped;
        }

        return Result.Fail<TResult>(failureMessage);
    }

    private static bool ShouldSkipRetry(string? finishReason) =>
        string.Equals(finishReason, "length", StringComparison.OrdinalIgnoreCase)
     || string.Equals(finishReason, "max_tokens", StringComparison.OrdinalIgnoreCase)
     || string.Equals(finishReason, "content_filter", StringComparison.OrdinalIgnoreCase);

    private TResponse? TryDeserialize<TResponse>(string json) where TResponse : class
    {
        try
        {
            return JsonSerializer.Deserialize<TResponse>(json, JsonOptions);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "{Agent} failed to parse LLM response.", GetType().Name);
            return null;
        }
    }
}
