using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;

namespace Tutor.BuildingBlocks.AI.Core.Agents;

/// <summary>
/// Base class for agents that stream a single-message LLM completion token by token.
/// Derived agents build their own system and user prompts and delegate the network plumbing here.
/// </summary>
public abstract class StreamingAgent
{
    protected IAiChatService ChatService { get; }

    protected StreamingAgent(IAiChatService chatService)
    {
        ChatService = chatService;
    }

    protected async IAsyncEnumerable<string> StreamAsync(
        string systemPrompt, string userMessage,
        int maxTokens, double temperature,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens, temperature);
        await foreach (var token in ChatService.StreamAsync(request, ct))
            yield return token;
    }
}
