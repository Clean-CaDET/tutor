using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.IntentClassifier;

public class IntentClassifierAgent : StructuredAgent, IIntentClassifier
{
    public IntentClassifierAgent(IAiChatService chatService, ILogger<IntentClassifierAgent> logger)
        : base(chatService, logger) { }

    public Task<Result<TurnIntent>> ClassifyAsync(
        string content, List<ConversationTurn> history,
        ConceptElaborationTask task, CancellationToken ct)
    {
        var systemPrompt = IntentPromptBuilder.BuildSystemPrompt(task);
        var userMessage = IntentPromptBuilder.BuildUserMessage(content, history);

        return CompleteJsonAsync<IntentResponse, TurnIntent>(
            systemPrompt, userMessage, maxTokens: 64, temperature: 0.0,
            validateAndMap: r => Enum.TryParse<TurnIntent>(r.Intent, ignoreCase: true, out var intent)
                ? Result.Ok(intent)
                : Result.Fail<TurnIntent>("Unrecognized intent."),
            failureMessage: "Intent classification failed.",
            ct);
    }

    private class IntentResponse { public string? Intent { get; set; } }
}
