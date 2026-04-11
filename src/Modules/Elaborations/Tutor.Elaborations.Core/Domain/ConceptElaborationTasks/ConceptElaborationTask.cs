using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class ConceptElaborationTask : AggregateRoot
{
    public int UnitId { get; internal set; }
    public int Order { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string CanonicalDefinition { get; private set; } = string.Empty;
    public List<KeyProposition> KeyPropositions { get; private set; } = new();
    public List<BoundaryCondition> BoundaryConditions { get; private set; } = new();
    public List<CommonMisconception> CommonMisconceptions { get; private set; } = new();
    public List<KeyRelation> KeyRelations { get; private set; } = new();

    public void Update(ConceptElaborationTask incoming)
    {
        Title = incoming.Title;
        CanonicalDefinition = incoming.CanonicalDefinition;
        Order = incoming.Order;
        KeyPropositions = incoming.KeyPropositions;
        BoundaryConditions = incoming.BoundaryConditions;
        CommonMisconceptions = incoming.CommonMisconceptions;
        KeyRelations = incoming.KeyRelations;
    }

    public bool AreAllPropositionsCovered(ConversationAttempt attempt)
    {
        var coveredIds = attempt.GetCoveredPropositionIds();
        return KeyPropositions.All(kp => coveredIds.Contains(kp.Id));
    }

    public bool AreAllKeyRelationsArticulated(ConversationAttempt attempt)
    {
        if (KeyRelations.Count == 0) return true;
        var articulatedIds = attempt.GetArticulatedRelationIds();
        return KeyRelations.All(kr => articulatedIds.Contains(kr.Id));
    }

    public bool IsAttemptComplete(ConversationAttempt attempt)
    {
        return AreAllPropositionsCovered(attempt) && AreAllKeyRelationsArticulated(attempt);
    }
}
