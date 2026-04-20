using System.Text.Json;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Infrastructure.Agents.Prompts;

namespace Tutor.Elaborations.Infrastructure.Agents;

public class EvaluationAgent : IEvaluationAgent
{
    private const int MaxAttempts = 2;
    private readonly IAiChatService _chatService;
    private readonly ILogger<EvaluationAgent> _logger;

    public EvaluationAgent(IAiChatService chatService, ILogger<EvaluationAgent> logger)
    {
        _chatService = chatService;
        _logger = logger;
    }

    public async Task<Result<TurnAnalysis>> AnalyzeAsync(string content,
        List<ConversationTurn> history, ConceptElaborationTask task, CancellationToken ct)
    {
        var request = CreateRequestWithPromptAndParams(content, history, task);

        for (var attempt = 0; attempt < MaxAttempts; attempt++)
        {
            var result = await _chatService.CompleteAsync(request, ct);
            if (result.IsFailed) continue;

            var analysis = TryParseResponse(result.Value.Content, task);
            if (analysis == null) continue;

            return analysis;
        }

        return Result.Fail("Failed to parse evaluation response after retries.");
    }

    private static CompletionRequest CreateRequestWithPromptAndParams(
        string content, List<ConversationTurn> history, ConceptElaborationTask task)
    {
        var systemPrompt = EvaluationPromptBuilder.BuildSystemPrompt(task);
        var userMessage = EvaluationPromptBuilder.BuildUserMessage(content, history);

        return CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 1024, temperature: 0.0);
    }

    private TurnAnalysis? TryParseResponse(string json, ConceptElaborationTask task)
    {
        try
        {
            var parsed = JsonSerializer.Deserialize<EvaluationResponse>(json,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            if (parsed == null || string.IsNullOrWhiteSpace(parsed.Intent)) return null;

            if (!Enum.TryParse<TurnIntent>(parsed.Intent, ignoreCase: true, out var intent))
                return null;

            if (intent != TurnIntent.Substantive)
                return new TurnAnalysis(intent, null);

            if (parsed.CorrectnessScore is < 1 or > 3) return null;
            if (parsed.CompletenessScore is < 1 or > 3) return null;
            if (parsed.DiscriminationScore is not null and (< 1 or > 3)) return null;
            if (parsed.IntegrationScore is not null and (< 1 or > 3)) return null;

            var validKpIds = task.KeyPropositions.Select(kp => kp.Id).ToHashSet();
            var validKrIds = task.KeyRelations.Select(kr => kr.Id).ToHashSet();
            var validCmIds = task.CommonMisconceptions.Select(cm => cm.Id).ToHashSet();

            if (parsed.PropositionsCoveredIds?.Any(id => !validKpIds.Contains(id)) == true) return null;
            if (parsed.RelationsArticulatedIds?.Any(id => !validKrIds.Contains(id)) == true) return null;
            if (parsed.MisconceptionsTriggeredIds?.Any(id => !validCmIds.Contains(id)) == true) return null;

            var evaluation = new TurnEvaluation(
                parsed.CorrectnessScore, parsed.CompletenessScore,
                parsed.DiscriminationScore, parsed.IntegrationScore,
                parsed.Justification ?? string.Empty, parsed.NovelMisconceptions,
                parsed.PropositionsCoveredIds ?? new List<int>(),
                parsed.MisconceptionsTriggeredIds ?? new List<int>(),
                parsed.RelationsArticulatedIds ?? new List<int>());
            return TurnAnalysis.Substantive(evaluation, parsed.HasMultipleConcerns ?? false);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "TryParseResponse failed to parse evaluation JSON.");
            return null;
        }
    }

    private class EvaluationResponse
    {
        public string? Intent { get; set; }
        public int CorrectnessScore { get; set; }
        public int CompletenessScore { get; set; }
        public int? DiscriminationScore { get; set; }
        public int? IntegrationScore { get; set; }
        public string? Justification { get; set; }
        public List<int>? PropositionsCoveredIds { get; set; }
        public List<int>? MisconceptionsTriggeredIds { get; set; }
        public List<int>? RelationsArticulatedIds { get; set; }
        public string? NovelMisconceptions { get; set; }
        public bool? HasMultipleConcerns { get; set; }
    }
}
