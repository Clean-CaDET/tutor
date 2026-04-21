using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Redirect;

public class RedirectAgent : IRedirectAgent
{
    private readonly IAiChatService _chatService;

    public RedirectAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> StreamAsync(
        ConceptElaborationTask task, [EnumeratorCancellation] CancellationToken ct)
    {
        var systemPrompt = RedirectPromptBuilder.BuildSystemPrompt(task);
        var userMessage = RedirectPromptBuilder.BuildUserMessage();
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 128, temperature: 0.7);

        await foreach (var token in _chatService.StreamAsync(request, ct))
            yield return token;
    }
}
