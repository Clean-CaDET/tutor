using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.Conversations;

/// <summary>
/// Service for generating AI chat completions.
/// </summary>
public interface IAiChatService
{
    Task<Result<CompletionResponse>> CompleteAsync(CompletionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Streams the completion response token by token as it's generated.
    /// </summary>
    IAsyncEnumerable<string> StreamAsync(CompletionRequest request, CancellationToken cancellationToken = default);
}
