using System.Text.Json;
using FluentResults;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Infrastructure.Agents.Prompts;

namespace Tutor.Elaborations.Infrastructure.Agents;

public class EvaluationAgent : IEvaluationAgent
{
    private readonly IAiChatService _chatService;

    public EvaluationAgent(IAiChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task<Result<EvaluationResult>> EvaluateAsync(string content,
        List<ConversationTurn> history, ConceptElaborationTask task,
        CancellationToken ct)
    {
        var systemPrompt = EvaluationPromptBuilder.BuildSystemPrompt(task);
        var messageData = EvaluationPromptBuilder.BuildMessages(content, history);

        var messages = messageData.Select(m =>
            m.role == "user" ? ChatMessage.FromUser(m.content) : ChatMessage.FromAssistant(m.content));

        var request = CompletionRequest.Create(messages, systemPrompt, maxTokens: 1024, temperature: 0.1);

        for (var attempt = 0; attempt < 2; attempt++)
        {
            var result = await _chatService.CompleteAsync(request, ct);
            if (result.IsFailed) continue;

            var parsed = TryParseResponse(result.Value.Content);
            if (parsed == null) continue;

            var evaluation = new TurnEvaluation(
                parsed.CorrectnessScore, parsed.CompletenessScore,
                parsed.DiscriminationScore, parsed.IntegrationScore,
                parsed.Justification ?? string.Empty, parsed.NovelMisconceptions,
                parsed.PropositionsCoveredIds ?? new List<int>(),
                parsed.MisconceptionsTriggeredIds ?? new List<int>(),
                parsed.RelationsArticulatedIds ?? new List<int>());

            return Result.Ok(new EvaluationResult(evaluation, parsed.IsSubstantive));
        }

        return Result.Fail("Failed to parse evaluation response after retries.");
    }

    private static EvaluationResponse? TryParseResponse(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<EvaluationResponse>(json,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }
        catch
        {
            return null;
        }
    }

    private class EvaluationResponse
    {
        public int CorrectnessScore { get; set; }
        public int CompletenessScore { get; set; }
        public int? DiscriminationScore { get; set; }
        public int? IntegrationScore { get; set; }
        public string? Justification { get; set; }
        public List<int>? PropositionsCoveredIds { get; set; }
        public List<int>? MisconceptionsTriggeredIds { get; set; }
        public List<int>? RelationsArticulatedIds { get; set; }
        public string? NovelMisconceptions { get; set; }
        public bool IsSubstantive { get; set; }
    }
}
