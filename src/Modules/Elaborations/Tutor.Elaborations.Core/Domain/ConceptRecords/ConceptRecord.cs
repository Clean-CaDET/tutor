using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.Domain.ConceptRecords;

public class ConceptRecord : AggregateRoot
{
    public int CourseId { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string CanonicalDefinition { get; private set; } = string.Empty;
    public List<KeyProposition> KeyPropositions { get; private set; } = new();
    public List<BoundaryCondition> BoundaryConditions { get; private set; } = new();
    public List<CommonMisconception> CommonMisconceptions { get; private set; } = new();
    public List<KeyRelation> KeyRelations { get; private set; } = new();

    public void Update(ConceptRecord conceptRecord)
    {
        Title = conceptRecord.Title;
        CanonicalDefinition = conceptRecord.CanonicalDefinition;
        KeyPropositions = conceptRecord.KeyPropositions;
        BoundaryConditions = conceptRecord.BoundaryConditions;
        CommonMisconceptions = conceptRecord.CommonMisconceptions;
        KeyRelations = conceptRecord.KeyRelations;
    }

    public ConceptRecord DeriveForLevel(PropositionLevel level)
    {
        var filteredKPs = KeyPropositions
            .Where(kp => kp.Level <= level)
            .OrderBy(kp => kp.Order).ToList();
        var filteredKPIds = filteredKPs.Select(kp => kp.Id).ToHashSet();

        return new ConceptRecord
        {
            Id = Id,
            CourseId = CourseId,
            Title = Title,
            CanonicalDefinition = CanonicalDefinition,
            KeyPropositions = filteredKPs,
            BoundaryConditions = BoundaryConditions
                .Where(bc => bc.Level <= level)
                .OrderBy(bc => bc.Order).ToList(),
            CommonMisconceptions = CommonMisconceptions
                .OrderBy(cm => cm.Order).ToList(),
            KeyRelations = KeyRelations
                .Where(kr => kr.Level <= level)
                .Where(kr => filteredKPIds.Contains(kr.SourceKeyPropositionId)
                          && filteredKPIds.Contains(kr.TargetKeyPropositionId))
                .OrderBy(kr => kr.Order).ToList()
        };
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
