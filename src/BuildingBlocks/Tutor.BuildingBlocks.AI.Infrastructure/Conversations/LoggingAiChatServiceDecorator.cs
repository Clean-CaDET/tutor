using System.Diagnostics;
using System.Runtime.CompilerServices;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Infrastructure.Conversations;

public class LoggingAiChatServiceDecorator : IAiChatService
{
    private readonly IAiChatService _inner;
    private readonly ILogger<LoggingAiChatServiceDecorator> _logger;

    public LoggingAiChatServiceDecorator(IAiChatService inner, ILogger<LoggingAiChatServiceDecorator> logger)
    {
        _inner = inner;
        _logger = logger;
    }

    public async Task<Result<CompletionResponse>> CompleteAsync(CompletionRequest request, CancellationToken cancellationToken = default)
    {
        var agent = ReadAgentName(request);
        var sw = Stopwatch.StartNew();

        var result = await _inner.CompleteAsync(request, cancellationToken);
        sw.Stop();

        if (result.IsFailed)
        {
            _logger.LogWarning(
                "LLM call failed. Agent={Agent} DurationMs={DurationMs} FailureReason={FailureReason}",
                agent, sw.ElapsedMilliseconds, string.Join("; ", result.Errors.Select(e => e.Message)));
            return result;
        }

        var response = result.Value;
        _logger.LogInformation(
            "LLM call ok. Agent={Agent} DurationMs={DurationMs} PromptTokens={PromptTokens} " +
            "CompletionTokens={CompletionTokens} ResponseChars={ResponseChars} FinishReason={FinishReason}",
            agent, sw.ElapsedMilliseconds, response.Usage.PromptTokens,
            response.Usage.CompletionTokens, response.Content.Length, response.FinishReason);

        return result;
    }

    public async IAsyncEnumerable<string> StreamAsync(CompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var agent = ReadAgentName(request);
        var sw = Stopwatch.StartNew();
        var charCount = 0;

        var enumerator = _inner.StreamAsync(request, cancellationToken).GetAsyncEnumerator(cancellationToken);
        try
        {
            while (true)
            {
                bool moved;
                try
                {
                    moved = await enumerator.MoveNextAsync();
                }
                catch (OperationCanceledException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    sw.Stop();
                    _logger.LogWarning(
                        "LLM stream failed. Agent={Agent} DurationMs={DurationMs} ResponseChars={ResponseChars} " +
                        "ExceptionType={ExceptionType} FailureReason={FailureReason}",
                        agent, sw.ElapsedMilliseconds, charCount, ex.GetType().Name, ex.Message);
                    throw;
                }

                if (!moved) break;

                var chunk = enumerator.Current;
                charCount += chunk.Length;
                yield return chunk;
            }
        }
        finally
        {
            await enumerator.DisposeAsync();
        }

        sw.Stop();
        _logger.LogInformation(
            "LLM stream ok. Agent={Agent} DurationMs={DurationMs} ResponseChars={ResponseChars}",
            agent, sw.ElapsedMilliseconds, charCount);
    }

    private static string ReadAgentName(CompletionRequest request)
    {
        if (request.Metadata != null && request.Metadata.TryGetValue("AgentName", out var name))
            return name?.ToString() ?? "unknown";
        return "unknown";
    }
}
