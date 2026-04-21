using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Probe;

public class ProbeAgent : IProbeAgent
{
    private readonly IAiChatService _chatService;

    public ProbeAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> StreamAsync(
        ProbeDirective directive, ConversationAttempt attempt, ConceptElaborationTask task,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var systemPrompt = ProbePromptBuilder.BuildSystemPrompt(task, directive, attempt.IsSoftCapReached());
        var userMessage = ProbePromptBuilder.BuildUserMessage(attempt.Turns.ToList());
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 256, temperature: 0.7);

        await foreach (var token in _chatService.StreamAsync(request, ct))
            yield return token;
    }
}
