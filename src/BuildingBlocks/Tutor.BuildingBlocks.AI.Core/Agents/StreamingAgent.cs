using System.Runtime.CompilerServices;
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

    protected StreamingAgent(IAiChatService chatService)
    {
        ChatService = chatService;
    }

    protected async IAsyncEnumerable<StreamOutput> StreamAsync(string systemPrompt, string userMessage,
        int maxTokens, double temperature, [EnumeratorCancellation] CancellationToken ct)
    {
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens, temperature)
            with { Metadata = new Dictionary<string, object> { ["AgentName"] = GetType().Name } };
        var tokenCount = 0;

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
                    throw;
                }
                catch (Exception ex)
                {
                    failure = $"Streaming call failed: {ex.Message}";
                }

                if (failure != null)
                {
                    yield return new StreamFailure(failure);
                    yield break;
                }
                if (!moved) break;

                if (!string.IsNullOrEmpty(token))
                {
                    tokenCount++;
                    yield return new StreamToken(token);
                }
            }
        }
        finally
        {
            await enumerator.DisposeAsync();
        }

        if (tokenCount == 0)
            yield return new StreamFailure("Empty response from LLM.");
    }
}
