using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Closing;

public class ClosingAgent : IClosingAgent
{
    private readonly IAiChatService _chatService;

    public ClosingAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> StreamAsync(
        ConceptElaborationTask task, ClosingReason reason,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var systemPrompt = ClosingPromptBuilder.BuildSystemPrompt(task, reason);
        var userMessage = ClosingPromptBuilder.BuildUserMessage();
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 128, temperature: 0.5);

        await foreach (var token in _chatService.StreamAsync(request, ct))
            yield return token;
    }
}
