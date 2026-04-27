using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.Domain.ConceptRecords;

public class ConceptRecord : Entity
{
    public int ConceptElaborationTaskId { get; private set; }
    public string CanonicalDefinition { get; private set; } = string.Empty;
    public List<KeyProposition> KeyPropositions { get; private set; } = [];
    public List<CommonMisconception> CommonMisconceptions { get; private set; } = [];
    public List<KeyRelation> KeyRelations { get; private set; } = [];

    private ConceptRecord() { }

    public ConceptRecord(
        int conceptElaborationTaskId, string canonicalDefinition,
        List<KeyProposition> keyPropositions, List<CommonMisconception> commonMisconceptions,
        List<KeyRelation> keyRelations)
    {
        ConceptElaborationTaskId = conceptElaborationTaskId;
        CanonicalDefinition = canonicalDefinition;
        KeyPropositions = keyPropositions;
        CommonMisconceptions = commonMisconceptions;
        KeyRelations = keyRelations;
    }

    public void Update(ConceptRecord incoming)
    {
        CanonicalDefinition = incoming.CanonicalDefinition;
        KeyPropositions = incoming.KeyPropositions;
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

    public string? PickNextTarget(ConversationAttempt attempt, IReadOnlySet<string>? excludedTargets = null)
    {
        var articulatedKps = attempt.GetArticulatedPropositionKeys();
        var nextTarget = KeyPropositions
            .Where(kp => !articulatedKps.Contains(kp.Key))
            .Select(kp => kp.Statement)
            .FirstOrDefault(s => excludedTargets == null || !excludedTargets.Contains(s));
        if (nextTarget != null) return nextTarget;

        var articulatedKrs = attempt.GetArticulatedRelationKeys();
        foreach (var kr in KeyRelations.Where(kr => !articulatedKrs.Contains(kr.Key)))
        {
            var source = KeyPropositions.First(kp => kp.Key == kr.SourceKey).Statement;
            var target = KeyPropositions.First(kp => kp.Key == kr.TargetKey).Statement;
            var composed = $"{source} → {target}. Mechanism: {kr.Mechanism}";
            if (excludedTargets == null || !excludedTargets.Contains(composed)) return composed;
        }

        return null;
    }

    public int CountPropositionsAndRelations()
    {
        return KeyPropositions.Count + KeyRelations.Count;
    }
}
