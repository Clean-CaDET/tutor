using FluentResults;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Agents;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

namespace Tutor.Elaborations.Infrastructure.Agents.Scorer;

public class ScorerAgent : StructuredAgent, IScorer
{
    public ScorerAgent(IAiChatService chatService, ILogger<ScorerAgent> logger)
        : base(chatService, logger) { }

    public Task<Result<TurnEvaluation>> ScoreAsync(
        string content, List<ConversationTurn> history,
        ConceptElaborationTask task, CancellationToken ct)
    {
        var systemPrompt = ScorerPromptBuilder.BuildSystemPrompt(task);
        var userMessage = ScorerPromptBuilder.BuildUserMessage(content, history);

        return CompleteJsonAsync<ScorerResponse, TurnEvaluation>(
            systemPrompt, userMessage, maxTokens: 1024, temperature: 0.0,
            validateAndMap: r => MapToEvaluation(r, task),
            failureMessage: "Scoring failed.",
            ct);
    }

    private static Result<TurnEvaluation> MapToEvaluation(ScorerResponse parsed, ConceptElaborationTask task)
    {
        if (parsed.CorrectnessScore is < 1 or > 3) return Result.Fail("Correctness out of range.");
        if (parsed.CompletenessScore is < 1 or > 3) return Result.Fail("Completeness out of range.");
        if (parsed.DiscriminationScore is not null and (< 1 or > 3)) return Result.Fail("Discrimination out of range.");
        if (parsed.IntegrationScore is not null and (< 1 or > 3)) return Result.Fail("Integration out of range.");

        var validKpIds = task.KeyPropositions.Select(kp => kp.Id).ToHashSet();
        var validKrIds = task.KeyRelations.Select(kr => kr.Id).ToHashSet();
        var validCmIds = task.CommonMisconceptions.Select(cm => cm.Id).ToHashSet();

        if (parsed.PropositionsCoveredIds?.Any(id => !validKpIds.Contains(id)) == true)
            return Result.Fail("Unknown proposition id.");
        if (parsed.RelationsArticulatedIds?.Any(id => !validKrIds.Contains(id)) == true)
            return Result.Fail("Unknown relation id.");
        if (parsed.MisconceptionsTriggeredIds?.Any(id => !validCmIds.Contains(id)) == true)
            return Result.Fail("Unknown misconception id.");

        return new TurnEvaluation(
            parsed.CorrectnessScore, parsed.CompletenessScore,
            parsed.DiscriminationScore, parsed.IntegrationScore,
            parsed.Justification ?? string.Empty, parsed.NovelMisconceptions,
            parsed.PropositionsCoveredIds ?? new List<int>(),
            parsed.MisconceptionsTriggeredIds ?? new List<int>(),
            parsed.RelationsArticulatedIds ?? new List<int>(),
            parsed.HasMultipleConcerns ?? false);
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
