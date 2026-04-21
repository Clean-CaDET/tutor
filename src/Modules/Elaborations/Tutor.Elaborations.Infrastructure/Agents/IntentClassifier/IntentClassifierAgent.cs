using System.Text.Json;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.IntentClassifier;

public class IntentClassifierAgent : IIntentClassifier
{
    private const int MaxAttempts = 2;
    private readonly IAiChatService _chatService;
    private readonly ILogger<IntentClassifierAgent> _logger;

    public IntentClassifierAgent(IAiChatService chatService, ILogger<IntentClassifierAgent> logger)
    {
        _chatService = chatService;
        _logger = logger;
    }

    public async Task<Result<TurnIntent>> ClassifyAsync(
        string content, List<ConversationTurn> history,
        ConceptElaborationTask task, CancellationToken ct)
    {
        var systemPrompt = IntentPromptBuilder.BuildSystemPrompt(task);
        var userMessage = IntentPromptBuilder.BuildUserMessage(content, history);
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 64, temperature: 0.0);

        for (var attempt = 0; attempt < MaxAttempts; attempt++)
        {
            var result = await _chatService.CompleteAsync(request, ct);
            if (result.IsFailed) continue;

            var intent = TryParse(result.Value.Content);
            if (intent.HasValue) return intent.Value;
        }

        return Result.Fail("Intent classification failed.");
    }

    private TurnIntent? TryParse(string json)
    {
        try
        {
            var parsed = JsonSerializer.Deserialize<IntentResponse>(json,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            if (parsed?.Intent is null) return null;
            return Enum.TryParse<TurnIntent>(parsed.Intent, ignoreCase: true, out var intent) ? intent : null;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "IntentClassifierAgent failed to parse response.");
            return null;
        }
    }

    private class IntentResponse { public string? Intent { get; set; } }
}
