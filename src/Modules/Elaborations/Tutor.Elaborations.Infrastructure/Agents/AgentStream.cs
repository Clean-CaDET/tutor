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
    private readonly AgentKind _kind;
    private readonly AgentConfig _config;

    public AgentStream(AgentKind kind, IAiChatService chatService, ITurnUsageTracker usageTracker, ILogger<AgentStream> logger)
        : base(chatService, usageTracker, logger)
    {
        _kind = kind;
        _config = AgentConfigs.ByKind[kind];
    }

    public IAsyncEnumerable<StreamOutput> StreamAsync(
        IReadOnlyList<ConversationTurn> history, ConceptRecord record,
        AgentTurnContext ctx, CancellationToken ct)
    {
        var messages = ConversationHistoryMapper.Map(history, _config.HistoryWindow);
        messages.Add(ChatMessage.FromUser(RuntimeContextBlock.Render(ctx)));

        var request = CompletionRequest.Create(
            messages, _config.BuildSystemPrompt(record),
            maxTokens: _config.MaxTokens, temperature: _config.Temperature);

        return StreamAsync(request, _kind.ToString(), ct);
    }
}
