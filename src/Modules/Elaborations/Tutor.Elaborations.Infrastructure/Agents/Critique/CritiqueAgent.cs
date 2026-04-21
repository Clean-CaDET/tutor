using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Critique;

public class CritiqueAgent : StreamingAgent, ICritiqueAgent
{
    public CritiqueAgent(IAiChatService chatService) : base(chatService) { }

    public IAsyncEnumerable<string> StreamAsync(
        TurnEvaluation evaluation, ConversationAttempt attempt, ConceptElaborationTask task,
        CancellationToken ct)
    {
        var systemPrompt = CritiquePromptBuilder.BuildSystemPrompt(task, attempt, attempt.IsSoftCapReached());
        var userMessage = CritiquePromptBuilder.BuildUserMessage(evaluation, attempt.Turns.ToList());
        return StreamAsync(systemPrompt, userMessage, maxTokens: 512, temperature: 0.7, ct);
    }
}
