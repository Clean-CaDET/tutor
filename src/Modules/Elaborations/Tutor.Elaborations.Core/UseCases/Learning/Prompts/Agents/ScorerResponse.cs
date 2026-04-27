namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

public class ScorerResponse
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
}
