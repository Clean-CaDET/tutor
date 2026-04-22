using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Closing;

public class ClosingAgent : StreamingAgent, IClosingAgent
{
    public ClosingAgent(IAiChatService chatService, ITurnUsageTracker usageTracker, ILogger<ClosingAgent> logger)
        : base(chatService, usageTracker, logger) { }

    public IAsyncEnumerable<StreamOutput> StreamAsync(
        ConceptElaborationTask task, ClosingReason reason, CancellationToken ct)
    {
        var systemPrompt = ClosingPromptBuilder.BuildSystemPrompt(task, reason);
        var userMessage = ClosingPromptBuilder.BuildUserMessage();
        return StreamAsync(systemPrompt, userMessage, maxTokens: 128, temperature: 0.5, ct);
    }
}
