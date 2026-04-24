using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.Domain.ConceptRecords;

public class ConceptRecord : Entity
{
    public int ConceptElaborationTaskId { get; private set; }
    public string CanonicalDefinition { get; private set; } = string.Empty;
    public List<KeyProposition> KeyPropositions { get; private set; } = new();
    public List<BoundaryCondition> BoundaryConditions { get; private set; } = new();
    public List<CommonMisconception> CommonMisconceptions { get; private set; } = new();
    public List<KeyRelation> KeyRelations { get; private set; } = new();

    private ConceptRecord() { }

    public ConceptRecord(
        int conceptElaborationTaskId, string canonicalDefinition,
        List<KeyProposition> keyPropositions, List<BoundaryCondition> boundaryConditions,
        List<CommonMisconception> commonMisconceptions, List<KeyRelation> keyRelations)
    {
        ConceptElaborationTaskId = conceptElaborationTaskId;
        CanonicalDefinition = canonicalDefinition;
        KeyPropositions = keyPropositions;
        BoundaryConditions = boundaryConditions;
        CommonMisconceptions = commonMisconceptions;
        KeyRelations = keyRelations;
    }

    public void Update(ConceptRecord incoming)
    {
        CanonicalDefinition = incoming.CanonicalDefinition;
        KeyPropositions = incoming.KeyPropositions;
        BoundaryConditions = incoming.BoundaryConditions;
        CommonMisconceptions = incoming.CommonMisconceptions;
        KeyRelations = incoming.KeyRelations;
    }

    public bool AreAllPropositionsCovered(ConversationAttempt attempt)
    {
        var covered = attempt.GetCoveredPropositionKeys();
        return KeyPropositions.All(kp => covered.Contains(kp.Key));
    }

    public bool AreAllKeyRelationsArticulated(ConversationAttempt attempt)
    {
        if (KeyRelations.Count == 0) return true;
        var articulated = attempt.GetArticulatedRelationKeys();
        return KeyRelations.All(kr => articulated.Contains(kr.Key));
    }

    public bool IsAttemptComplete(ConversationAttempt attempt)
    {
        return AreAllPropositionsCovered(attempt) && AreAllKeyRelationsArticulated(attempt);
    }

    public List<string> GetUncoveredPropositionKeys(ConversationAttempt attempt)
    {
        var covered = attempt.GetCoveredPropositionKeys();
        return KeyPropositions.Where(kp => !covered.Contains(kp.Key)).Select(kp => kp.Key).ToList();
    }

    public List<string> GetUnarticulatedRelationKeys(ConversationAttempt attempt)
    {
        var articulated = attempt.GetArticulatedRelationKeys();
        return KeyRelations.Where(kr => !articulated.Contains(kr.Key)).Select(kr => kr.Key).ToList();
    }
}
