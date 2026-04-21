using System.Text.Json;
using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Scorer;

public class ScorerAgent : IScorer
{
    private const int MaxAttempts = 2;
    private readonly IAiChatService _chatService;
    private readonly ILogger<ScorerAgent> _logger;

    public ScorerAgent(IAiChatService chatService, ILogger<ScorerAgent> logger)
    {
        _chatService = chatService;
        _logger = logger;
    }

    public async Task<Result<TurnEvaluation>> ScoreAsync(
        string content, List<ConversationTurn> history,
        ConceptElaborationTask task, CancellationToken ct)
    {
        var systemPrompt = ScorerPromptBuilder.BuildSystemPrompt(task);
        var userMessage = ScorerPromptBuilder.BuildUserMessage(content, history);
        var request = CompletionRequest.SingleMessage(userMessage, systemPrompt, maxTokens: 1024, temperature: 0.0);

        for (var attempt = 0; attempt < MaxAttempts; attempt++)
        {
            var result = await _chatService.CompleteAsync(request, ct);
            if (result.IsFailed) continue;

            var evaluation = TryParse(result.Value.Content, task);
            if (evaluation != null) return evaluation;
        }

        return Result.Fail("Scoring failed.");
    }

    private TurnEvaluation? TryParse(string json, ConceptElaborationTask task)
    {
        try
        {
            var parsed = JsonSerializer.Deserialize<ScorerResponse>(json,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            if (parsed == null) return null;

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

            return new TurnEvaluation(
                parsed.CorrectnessScore, parsed.CompletenessScore,
                parsed.DiscriminationScore, parsed.IntegrationScore,
                parsed.Justification ?? string.Empty, parsed.NovelMisconceptions,
                parsed.PropositionsCoveredIds ?? new List<int>(),
                parsed.MisconceptionsTriggeredIds ?? new List<int>(),
                parsed.RelationsArticulatedIds ?? new List<int>(),
                parsed.HasMultipleConcerns ?? false);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "ScorerAgent failed to parse response.");
            return null;
        }
    }

    private class ScorerResponse
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
        public bool? HasMultipleConcerns { get; set; }
    }
}
