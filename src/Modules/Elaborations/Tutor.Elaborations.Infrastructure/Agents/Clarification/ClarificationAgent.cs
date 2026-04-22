using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Clarification;

public class ClarificationAgent : StreamingAgent, IClarificationAgent
{
    public ClarificationAgent(IAiChatService chatService, ITurnUsageTracker usageTracker, ILogger<ClarificationAgent> logger)
        : base(chatService, usageTracker, logger) { }

    public IAsyncEnumerable<StreamOutput> StreamAsync(
        ConversationAttempt attempt, ConceptElaborationTask task, ProbeDirective? lastProbe,
        CancellationToken ct)
    {
        var history = attempt.Turns.ToList();
        var learnerContent = history.LastOrDefault(t => t.Role == TurnRole.Learner)?.Content ?? string.Empty;

        var systemPrompt = ClarificationPromptBuilder.BuildSystemPrompt(task, lastProbe);
        var userMessage = ClarificationPromptBuilder.BuildUserMessage(history, learnerContent);
        return StreamAsync(systemPrompt, userMessage, maxTokens: 256, temperature: 0.5, ct);
    }
}
