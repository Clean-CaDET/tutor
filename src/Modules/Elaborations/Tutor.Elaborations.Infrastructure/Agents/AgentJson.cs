using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;

namespace Tutor.Elaborations.Infrastructure.Agents;

public class AgentJson : StructuredAgent, IAgentJson
{
    private readonly AgentKind _kind;
    private readonly AgentConfig _config;

    public AgentJson(AgentKind kind, IAiChatService chatService, ILogger<AgentJson> logger)
        : base(chatService, logger)
    {
        _kind = kind;
        _config = AgentConfigs.ByKind[kind];
    }

    public Task<Result<TResult>> CompleteAsync<TResponse, TResult>(
        IReadOnlyList<ConversationTurn> history, ConceptRecord record,
        AgentTurnContext ctx, Func<TResponse, Result<TResult>> validateAndMap,
        string failureMessage, CancellationToken ct) where TResponse : class
    {
        var messages = ConversationHistoryMapper.Map(history, _config.HistoryWindow);
        messages.Add(ChatMessage.FromUser(RuntimeContextBlock.Render(ctx)));

        var request = CompletionRequest.Create(
            messages, _config.BuildSystemPrompt(record),
            maxTokens: _config.MaxTokens, temperature: _config.Temperature);

        return CompleteJsonAsync(request, _kind.ToString(), validateAndMap, failureMessage, ct);
    }
}
