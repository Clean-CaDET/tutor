using System.Runtime.CompilerServices;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Critique;

public class CritiqueAgent : ICritiqueAgent
{
    private readonly IAiChatService _chatService;

    public CritiqueAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async IAsyncEnumerable<string> StreamAsync(
        TurnEvaluation evaluation, ConversationAttempt attempt, ConceptElaborationTask task,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var systemPrompt = CritiquePromptBuilder.BuildSystemPrompt(task, attempt, attempt.IsSoftCapReached());
        var userMessage = CritiquePromptBuilder.BuildUserMessage(evaluation, attempt.Turns.ToList());
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 512, temperature: 0.7);

        await foreach (var token in _chatService.StreamAsync(request, ct))
            yield return token;
    }
}
