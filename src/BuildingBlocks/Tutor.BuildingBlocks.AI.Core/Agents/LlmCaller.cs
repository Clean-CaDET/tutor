using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Core.Agents;

public abstract class LlmCaller
{
    private const int MaxJsonAttempts = 2;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private readonly IAiChatService _chatService;
    private readonly ITurnUsageTracker _usageTracker;
    private readonly ILogger _logger;

    protected LlmCaller(IAiChatService chatService, ITurnUsageTracker usageTracker, ILogger logger)
    {
        _chatService = chatService;
        _usageTracker = usageTracker;
        _logger = logger;
    }

    protected async Task<Result<TResponse>> CompleteJsonAsync<TResponse>(
        CompletionRequest request, string label, CancellationToken ct) where TResponse : class
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
            for (var attempt = 0; attempt < MaxJsonAttempts; attempt++)
            {
                attempts = attempt + 1;
                var completion = await _chatService.CompleteAsync(request, ct);
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
                    _logger.LogWarning("{Label} skipping retry due to deterministic finish reason '{FinishReason}'.",
                        label, completion.Value.FinishReason);
                    failureCategory = "permanent";
                    break;
                }

                var parsed = TryDeserialize<TResponse>(completion.Value.Content, label);
                if (parsed is null)
                {
                    failureCategory = "parse";
                    continue;
                }

                status = "ok";
                failureCategory = null;
                return parsed;
            }

            return Result.Fail($"{label} failed.");
        }
        finally
        {
            sw.Stop();
            var level = status == "ok" ? LogLevel.Information : LogLevel.Warning;
            _logger.Log(level,
                "Agent={Agent} Status={Status} DurationMs={DurationMs} PromptTokens={PromptTokens} " +
                "CompletionTokens={CompletionTokens} ResponseChars={ResponseChars} Attempts={Attempts} " +
                "FailureCategory={FailureCategory}",
                label, status, sw.ElapsedMilliseconds,
                promptTokens, completionTokens, charCount, attempts, failureCategory);
        }
    }

    protected async IAsyncEnumerable<StreamOutput> StreamAsync(
        CompletionRequest request, string label, [EnumeratorCancellation] CancellationToken ct)
    {
        var sw = Stopwatch.StartNew();
        var usageBefore = _usageTracker.Total;
        var charCount = 0;
        var status = "ok";
        string? failureCategory = null;

        try
        {
            var enumerator = _chatService.StreamAsync(request, ct).GetAsyncEnumerator(ct);
            try
            {
                while (true)
                {
                    string? token = null;
                    string? failure = null;
                    var moved = false;

                    try
                    {
                        moved = await enumerator.MoveNextAsync();
                        if (moved) token = enumerator.Current;
                    }
                    catch (OperationCanceledException)
                    {
                        status = "cancelled";
                        failureCategory = "cancelled";
                        throw;
                    }
                    catch (Exception ex)
                    {
                        failure = $"Streaming call failed: {ex.Message}";
                    }

                    if (failure != null)
                    {
                        status = "failure";
                        failureCategory = "transient";
                        yield return new StreamFailure(failure);
                        yield break;
                    }
                    if (!moved) break;

                    if (!string.IsNullOrEmpty(token))
                    {
                        charCount += token.Length;
                        yield return new StreamToken(token);
                    }
                }
            }
            finally
            {
                await enumerator.DisposeAsync();
            }

            if (charCount == 0)
            {
                status = "empty";
                failureCategory = "empty";
                yield return new StreamFailure("Empty response from LLM.");
            }
        }
        finally
        {
            sw.Stop();
            var delta = _usageTracker.Total.Subtract(usageBefore);
            var level = status == "ok" ? LogLevel.Information : LogLevel.Warning;
            _logger.Log(level,
                "Agent={Agent} Status={Status} DurationMs={DurationMs} PromptTokens={PromptTokens} " +
                "CompletionTokens={CompletionTokens} ResponseChars={ResponseChars} Attempts={Attempts} " +
                "FailureCategory={FailureCategory}",
                label, status, sw.ElapsedMilliseconds,
                delta.PromptTokens, delta.CompletionTokens, charCount, 1, failureCategory);
        }
    }

    private static bool ShouldSkipRetry(string? finishReason) =>
        string.Equals(finishReason, "length", StringComparison.OrdinalIgnoreCase)
     || string.Equals(finishReason, "max_tokens", StringComparison.OrdinalIgnoreCase)
     || string.Equals(finishReason, "content_filter", StringComparison.OrdinalIgnoreCase);

    private TResponse? TryDeserialize<TResponse>(string json, string label) where TResponse : class
    {
        try
        {
            return JsonSerializer.Deserialize<TResponse>(json, JsonOptions);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "{Label} failed to parse LLM response.", label);
            return null;
        }
    }
}
