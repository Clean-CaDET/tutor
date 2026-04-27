using System.Diagnostics;
using System.Text.Json;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Core.Agents;

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

    protected async Task<Result<TResponse>> CompleteJsonAsync<TResponse>(
        CompletionRequest request, string agentLabel, CancellationToken ct) where TResponse : class
    {
        var sw = Stopwatch.StartNew();
        var promptTokens = 0;
        var completionTokens = 0;
        var charCount = 0;
        var attempts = 0;
        var status = "failure";
        string? failureCategory = "transient";

        try
        {
            for (var attempt = 0; attempt < MaxAttempts; attempt++)
            {
                attempts = attempt + 1;
                var completion = await ChatService.CompleteAsync(request, ct);
                if (completion.IsFailed)
                {
                    failureCategory = "transient";
                    continue;
                }

                promptTokens += completion.Value.Usage.PromptTokens;
                completionTokens += completion.Value.Usage.CompletionTokens;
                charCount += completion.Value.Content.Length;

                if (ShouldSkipRetry(completion.Value.FinishReason))
                {
                    _logger.LogWarning(
                        "{Agent} skipping retry due to deterministic finish reason '{FinishReason}'.",
                        agentLabel, completion.Value.FinishReason);
                    failureCategory = "permanent";
                    break;
                }

                var parsed = TryDeserialize<TResponse>(completion.Value.Content, agentLabel);
                if (parsed is null)
                {
                    failureCategory = "parse";
                    continue;
                }

                status = "ok";
                failureCategory = null;
                return parsed;
            }

            return Result.Fail($"{agentLabel} failed.");
        }
        finally
        {
            sw.Stop();
            var level = status == "ok" ? LogLevel.Information : LogLevel.Warning;
            _logger.Log(level,
                "Agent={Agent} Status={Status} DurationMs={DurationMs} PromptTokens={PromptTokens} " +
                "CompletionTokens={CompletionTokens} ResponseChars={ResponseChars} Attempts={Attempts} " +
                "FailureCategory={FailureCategory}",
                agentLabel, status, sw.ElapsedMilliseconds,
                promptTokens, completionTokens, charCount, attempts, failureCategory);
        }
    }

    private static bool ShouldSkipRetry(string? finishReason) =>
        string.Equals(finishReason, "length", StringComparison.OrdinalIgnoreCase)
     || string.Equals(finishReason, "max_tokens", StringComparison.OrdinalIgnoreCase)
     || string.Equals(finishReason, "content_filter", StringComparison.OrdinalIgnoreCase);

    private TResponse? TryDeserialize<TResponse>(string json, string agentLabel) where TResponse : class
    {
        try
        {
            return JsonSerializer.Deserialize<TResponse>(json, JsonOptions);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "{Agent} failed to parse LLM response.", agentLabel);
            return null;
        }
    }
}
