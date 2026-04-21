using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class TurnEvaluation : Entity
{
    public int ConversationTurnId { get; private set; }
    public int CorrectnessScore { get; private set; }
    public int CompletenessScore { get; private set; }
    public int? DiscriminationScore { get; private set; }
    public int? IntegrationScore { get; private set; }
    public string Justification { get; private set; } = string.Empty;
    public string? NovelMisconceptions { get; private set; }
    public List<int> PropositionsCoveredIds { get; private set; } = new();
    public List<int> MisconceptionsTriggeredIds { get; private set; } = new();
    public List<int> RelationsArticulatedIds { get; private set; } = new();
    public bool HasMultipleConcerns { get; private set; }

    private TurnEvaluation() { }

    public TurnEvaluation(
        int correctnessScore, int completenessScore,
        int? discriminationScore, int? integrationScore,
        string justification, string? novelMisconceptions,
        List<int> propositionsCoveredIds, List<int> misconceptionsTriggeredIds,
        List<int> relationsArticulatedIds, bool hasMultipleConcerns)
    {
        CorrectnessScore = correctnessScore;
        CompletenessScore = completenessScore;
        DiscriminationScore = discriminationScore;
        IntegrationScore = integrationScore;
        Justification = justification;
        NovelMisconceptions = novelMisconceptions;
        PropositionsCoveredIds = propositionsCoveredIds;
        MisconceptionsTriggeredIds = misconceptionsTriggeredIds;
        RelationsArticulatedIds = relationsArticulatedIds;
        HasMultipleConcerns = hasMultipleConcerns;
    }
}
