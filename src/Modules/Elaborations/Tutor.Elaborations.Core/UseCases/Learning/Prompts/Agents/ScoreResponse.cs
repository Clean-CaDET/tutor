using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

public class ScoreResponse
{
    public int CorrectnessScore { get; set; }
    public int CompletenessScore { get; set; }
    public int? IntegrationScore { get; set; }
    public string? Justification { get; set; }
    public List<string>? PropositionsCoveredKeys { get; set; }
    public List<string>? MisconceptionsTriggeredKeys { get; set; }
    public List<string>? RelationsArticulatedKeys { get; set; }
    public string? NovelMisconceptions { get; set; }
    public bool? HasMultipleConcerns { get; set; }

    public Result<TurnEvaluation> ToEvaluation(ConceptRecord record)
    {
        if (CorrectnessScore is < 0 or > 5) return Result.Fail("Correctness out of range.");
        if (CompletenessScore is < 0 or > 5) return Result.Fail("Completeness out of range.");
        if (IntegrationScore is not null and (< 0 or > 5)) return Result.Fail("Integration out of range.");

        var validKpKeys = record.KeyPropositions.Select(kp => kp.Key).ToHashSet();
        var validKrKeys = record.KeyRelations.Select(kr => kr.Key).ToHashSet();
        var validCmKeys = record.CommonMisconceptions.Select(cm => cm.Key).ToHashSet();

        if (PropositionsCoveredKeys?.Any(k => !validKpKeys.Contains(k)) == true)
            return Result.Fail("Unknown proposition key.");
        if (RelationsArticulatedKeys?.Any(k => !validKrKeys.Contains(k)) == true)
            return Result.Fail("Unknown relation key.");
        if (MisconceptionsTriggeredKeys?.Any(k => !validCmKeys.Contains(k)) == true)
            return Result.Fail("Unknown misconception key.");

        return CreateEvaluation();
    }

    private TurnEvaluation CreateEvaluation()
    {
        return new TurnEvaluation(
            CorrectnessScore, CompletenessScore, IntegrationScore,
            Justification ?? string.Empty, NovelMisconceptions, PropositionsCoveredKeys ?? [],
            MisconceptionsTriggeredKeys ?? [], RelationsArticulatedKeys ?? [],
            HasMultipleConcerns ?? false);
    }
}
