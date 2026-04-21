using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Clarification;

public class ClarificationAgent : IClarificationAgent
{
    private readonly IAiChatService _chatService;

    public ClarificationAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> StreamAsync(
        ConversationAttempt attempt, ConceptElaborationTask task, ProbeDirective? lastProbe,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var history = attempt.Turns.ToList();
        var learnerContent = history.LastOrDefault(t => t.Role == TurnRole.Learner)?.Content ?? string.Empty;

        var systemPrompt = ClarificationPromptBuilder.BuildSystemPrompt(task, lastProbe);
        var userMessage = ClarificationPromptBuilder.BuildUserMessage(history, learnerContent);
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 256, temperature: 0.5);

        await foreach (var token in _chatService.StreamAsync(request, ct))
            yield return token;
    }
}
