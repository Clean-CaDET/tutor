using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Scaffolding;

public class ScaffoldingAgent : IScaffoldingAgent
{
    private readonly IAiChatService _chatService;

    public ScaffoldingAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> StreamAsync(
        ProbeDirective target, ConversationAttempt attempt, ConceptElaborationTask task,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var systemPrompt = ScaffoldingPromptBuilder.BuildSystemPrompt(task, target);
        var userMessage = ScaffoldingPromptBuilder.BuildUserMessage(attempt);
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 512, temperature: 0.7);

        await foreach (var token in _chatService.StreamAsync(request, ct))
            yield return token;
    }
}
