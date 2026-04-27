using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class TurnEvaluation : Entity
{
    public int ConversationTurnId { get; private set; }
    // 0-5: accuracy of stated claims against key propositions
    public int CorrectnessScore { get; private set; }
    // 0-5: coverage of essential key propositions in the learner message
    public int CompletenessScore { get; private set; }
    // 0-5: whether learner articulated key relations with their causal mechanism; null when no key relations exist
    public int? IntegrationScore { get; private set; }
    public string Justification { get; private set; } = string.Empty;
    public string? NovelMisconceptions { get; private set; }
    public List<string> PropositionsCoveredKeys { get; private set; } = new();
    public List<string> MisconceptionsTriggeredKeys { get; private set; } = new();
    public List<string> RelationsArticulatedKeys { get; private set; } = new();
    public bool HasMultipleConcerns { get; private set; }

    private TurnEvaluation() { }

    public TurnEvaluation(
        int correctnessScore, int completenessScore, int? integrationScore,
        string justification, string? novelMisconceptions, List<string> propositionsCoveredKeys,
        List<string> misconceptionsTriggeredKeys, List<string> relationsArticulatedKeys, bool hasMultipleConcerns)
    {
        CorrectnessScore = correctnessScore;
        CompletenessScore = completenessScore;
        IntegrationScore = integrationScore;
        Justification = justification;
        NovelMisconceptions = novelMisconceptions;
        PropositionsCoveredKeys = propositionsCoveredKeys;
        MisconceptionsTriggeredKeys = misconceptionsTriggeredKeys;
        RelationsArticulatedKeys = relationsArticulatedKeys;
        HasMultipleConcerns = hasMultipleConcerns;
    }

    public int Grade()
    {
        var dims = new List<int> { CorrectnessScore, CompletenessScore };
        if (IntegrationScore is int i) dims.Add(i);
        return (int)Math.Round(dims.Average() * 2);
    }
}
