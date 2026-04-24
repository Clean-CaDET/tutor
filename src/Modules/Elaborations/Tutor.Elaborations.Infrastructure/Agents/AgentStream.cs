using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;

namespace Tutor.Elaborations.Infrastructure.Agents;

public class AgentStream : StreamingAgent, IAgentStream
{
    public AgentStream(IAiChatService chatService, ITurnUsageTracker usageTracker, ILogger<AgentStream> logger)
        : base(chatService, usageTracker, logger) { }

    public IAsyncEnumerable<StreamOutput> StreamAsync(
        AgentKind kind, IReadOnlyList<ConversationTurn> history,
        ConceptRecord record, AgentTurnContext ctx, CancellationToken ct)
    {
        var config = AgentConfigs.ByKind[kind];
        var messages = ConversationHistoryMapper.Map(history, config.HistoryWindow);
        messages.Add(ChatMessage.FromUser(RuntimeContextBlock.Render(ctx)));

        var request = CompletionRequest.Create(
            messages, config.BuildSystemPrompt(record),
            maxTokens: config.MaxTokens, temperature: config.Temperature);

        return StreamAsync(request, kind.ToString(), ct);
    }
}
