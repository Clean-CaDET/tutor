using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.Conversations;

public interface IAiChatService
{
    Task<Result<CompletionResponse>> CompleteAsync(CompletionRequest request, CancellationToken cancellationToken = default);
    IAsyncEnumerable<string> StreamAsync(CompletionRequest request, CancellationToken cancellationToken = default);
}
