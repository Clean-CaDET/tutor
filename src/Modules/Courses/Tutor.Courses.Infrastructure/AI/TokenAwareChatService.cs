using FluentResults;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Internal;
using Tutor.Courses.Core.Domain.TokenWallet;

namespace Tutor.Courses.Infrastructure.AI;

/// <summary>
/// Decorator that wraps IAiChatService to check/record token spending.
/// Call sites should add TokenSpendingContext to the request metadata.
/// TODO: Might not need this if we switch to a more integrated AI service that tracks usage itself.
/// </summary>
public class TokenAwareChatService : IAiChatService
{
    private const string TokenContextKey = "TokenContext";

    private readonly IAiChatService _inner;
    private readonly ITokenSpendingService _tokenSpending;

    public TokenAwareChatService(IAiChatService inner, ITokenSpendingService tokenSpending)
    {
        _inner = inner;
        _tokenSpending = tokenSpending;
    }

    public async Task<Result<CompletionResponse>> CompleteAsync(CompletionRequest request, CancellationToken cancellationToken = default)
    {
        var context = ExtractContext(request);
        if (context == null)
        {
            // No token tracking needed
            return await _inner.CompleteAsync(request, cancellationToken);
        }

        // Make the actual AI call
        var response = await _inner.CompleteAsync(request, cancellationToken);
        if (response.IsFailed) return response;

        // Record actual usage after the call
        var spendingRequest = new TokenSpendingRequestDto
        {
            LearnerId = context.LearnerId,
            CourseId = context.CourseId,
            UnitId = context.UnitId,
            PromptTokens = response.Value.Usage.PromptTokens,
            CompletionTokens = response.Value.Usage.CompletionTokens,
            FeatureType = context.FeatureType.ToString(),
            EntityId = context.EntityId,
            PromptSummary = TruncatePrompt(request)
        };

        var spendResult = _tokenSpending.SpendTokens(spendingRequest);
        if (spendResult.IsFailed)
        {
            // Log but don't fail the response - tokens were already used
            // In a production system, you might want to handle this differently
        }

        return response;
    }

    public IAsyncEnumerable<string> StreamAsync(CompletionRequest request, CancellationToken cancellationToken = default)
    {
        // For streaming, we record an estimate after completion
        // A more sophisticated approach would track actual tokens
        return StreamWithTracking(request, cancellationToken);
    }

    private async IAsyncEnumerable<string> StreamWithTracking(
        CompletionRequest request,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var context = ExtractContext(request);
        var estimatedPromptTokens = EstimatePromptTokens(request);
        var completionTokenCount = 0;

        await foreach (var chunk in _inner.StreamAsync(request, cancellationToken))
        {
            completionTokenCount += EstimateChunkTokens(chunk);
            yield return chunk;
        }

        // Record usage after stream completes
        if (context != null)
        {
            var spendingRequest = new TokenSpendingRequestDto
            {
                LearnerId = context.LearnerId,
                CourseId = context.CourseId,
                UnitId = context.UnitId,
                PromptTokens = estimatedPromptTokens,
                CompletionTokens = completionTokenCount,
                FeatureType = context.FeatureType.ToString(),
                EntityId = context.EntityId,
                PromptSummary = TruncatePrompt(request)
            };
            _tokenSpending.SpendTokens(spendingRequest);
        }
    }

    private static TokenSpendingContext? ExtractContext(CompletionRequest request)
    {
        if (request.Metadata?.TryGetValue(TokenContextKey, out var contextObj) == true &&
            contextObj is TokenSpendingContext context)
        {
            return context;
        }
        return null;
    }

    private static int EstimatePromptTokens(CompletionRequest request)
    {
        var charCount = request.Messages.Sum(m => m.Content.Length);
        if (!string.IsNullOrEmpty(request.SystemPrompt))
            charCount += request.SystemPrompt.Length;
        return (charCount / 4) + 50; // Rough estimate: ~4 chars per token + buffer
    }

    private static int EstimateChunkTokens(string chunk)
    {
        // Rough estimate for streaming chunks
        return Math.Max(1, chunk.Length / 4);
    }

    private static string? TruncatePrompt(CompletionRequest request)
    {
        var lastUserMessage = request.Messages.LastOrDefault(m => m.Role == ChatRole.User);
        if (lastUserMessage == null) return null;

        return lastUserMessage.Content.Length > 100
            ? lastUserMessage.Content[..100] + "..."
            : lastUserMessage.Content;
    }
}

/// <summary>
/// Context for token spending tracking. Add to CompletionRequest.Metadata with key "TokenContext".
/// </summary>
public record TokenSpendingContext(
    int LearnerId,
    int CourseId,
    int UnitId,
    AiFeatureType FeatureType,
    int? EntityId
);
