using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Core.Agents;

/// <summary>
/// Base class for agents that stream a single-message LLM completion token by token.
/// Derived agents build their own system and user prompts and delegate the network plumbing here.
/// Yields <see cref="StreamToken"/> per content chunk and a terminal <see cref="StreamFailure"/>
/// on provider exception or empty response.
/// </summary>
public abstract class StreamingAgent
{
    protected IAiChatService ChatService { get; }
    private readonly ITurnUsageTracker _usageTracker;
    private readonly ILogger _logger;

    protected StreamingAgent(IAiChatService chatService, ITurnUsageTracker usageTracker, ILogger logger)
    {
        ChatService = chatService;
        _usageTracker = usageTracker;
        _logger = logger;
    }

    protected async IAsyncEnumerable<StreamOutput> StreamAsync(string systemPrompt, string userMessage,
        int maxTokens, double temperature, [EnumeratorCancellation] CancellationToken ct)
    {
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens, temperature);

        var sw = Stopwatch.StartNew();
        var usageBefore = _usageTracker.Total;
        var charCount = 0;
        var status = "ok";
        string? failureCategory = null;

        try
        {
            var enumerator = ChatService.StreamAsync(request, ct).GetAsyncEnumerator(ct);
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
                GetType().Name, status, sw.ElapsedMilliseconds,
                delta.PromptTokens, delta.CompletionTokens, charCount, 1, failureCategory);
        }
    }
}
