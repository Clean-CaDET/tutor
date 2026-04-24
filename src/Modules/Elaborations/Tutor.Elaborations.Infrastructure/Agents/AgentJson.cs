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
    public AgentJson(IAiChatService chatService, ILogger<AgentJson> logger)
        : base(chatService, logger) { }

    public Task<Result<TResult>> CompleteAsync<TResponse, TResult>(
        AgentKind kind, IReadOnlyList<ConversationTurn> history,
        ConceptRecord record, AgentTurnContext ctx,
        Func<TResponse, Result<TResult>> validateAndMap,
        string failureMessage, CancellationToken ct) where TResponse : class
    {
        var config = AgentConfigs.ByKind[kind];
        var messages = ConversationHistoryMapper.Map(history, config.HistoryWindow);
        messages.Add(ChatMessage.FromUser(RuntimeContextBlock.Render(ctx)));

        var request = CompletionRequest.Create(
            messages, config.BuildSystemPrompt(record),
            maxTokens: config.MaxTokens, temperature: config.Temperature);

        return CompleteJsonAsync(request, kind.ToString(), validateAndMap, failureMessage, ct);
    }
}
