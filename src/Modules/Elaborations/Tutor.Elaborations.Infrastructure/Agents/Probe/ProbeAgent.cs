using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Probe;

public class ProbeAgent : StreamingAgent, IProbeAgent
{
    public ProbeAgent(IAiChatService chatService, ITurnUsageTracker usageTracker, ILogger<ProbeAgent> logger)
        : base(chatService, usageTracker, logger) { }

    public IAsyncEnumerable<StreamOutput> StreamAsync(
        ProbeDirective directive, ConversationAttempt attempt, ConceptElaborationTask task,
        CancellationToken ct)
    {
        var systemPrompt = ProbePromptBuilder.BuildSystemPrompt(task, directive, attempt.IsSoftCapReached());
        var userMessage = ProbePromptBuilder.BuildUserMessage(attempt.Turns.ToList());
        return StreamAsync(systemPrompt, userMessage, maxTokens: 256, temperature: 0.7, ct);
    }
}
