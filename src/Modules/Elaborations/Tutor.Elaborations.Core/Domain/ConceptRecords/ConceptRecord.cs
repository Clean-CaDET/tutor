using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.Domain.ConceptRecords;

public class ConceptRecord : Entity
{
    public int ConceptElaborationTaskId { get; private set; }
    public string CanonicalDefinition { get; private set; } = string.Empty;
    public List<KeyProposition> KeyPropositions { get; private set; } = [];
    public List<BoundaryCondition> BoundaryConditions { get; private set; } = [];
    public List<CommonMisconception> CommonMisconceptions { get; private set; } = [];
    public List<KeyRelation> KeyRelations { get; private set; } = [];

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
        var covered = attempt.GetArticulatedPropositionKeys();
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

    public string PickNextTarget(ConversationAttempt attempt)
    {
        var articulatedKps = attempt.GetArticulatedPropositionKeys();
        var nextTarget = KeyPropositions.Where(kp => !articulatedKps.Contains(kp.Key))
            .Select(kp => kp.Statement).FirstOrDefault();
        if (nextTarget != null) return nextTarget;

        var articulatedKrs = attempt.GetArticulatedRelationKeys();
        var nextRelation = KeyRelations.First(kr => !articulatedKrs.Contains(kr.Key));
        var source = KeyPropositions.First(kp => kp.Key == nextRelation.SourceKey).Statement;
        var target = KeyPropositions.First(kp => kp.Key == nextRelation.TargetKey).Statement;
        return $"{source} → {target}. Mechanism: {nextRelation.Mechanism}";
    }

    public int CountPropositionsAndRelations()
    {
        return KeyPropositions.Count + KeyRelations.Count;
    }
}
