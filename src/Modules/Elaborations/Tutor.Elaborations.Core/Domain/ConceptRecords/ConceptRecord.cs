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

    public void Update(ConceptRecord conceptRecord)
    {
        Title = conceptRecord.Title;
        CanonicalDefinition = conceptRecord.CanonicalDefinition;
        KeyPropositions = conceptRecord.KeyPropositions;
        BoundaryConditions = conceptRecord.BoundaryConditions;
        CommonMisconceptions = conceptRecord.CommonMisconceptions;
    }

    public ConceptRecord DeriveForLevel(PropositionLevel level)
    {
        return new ConceptRecord
        {
            Id = Id,
            CourseId = CourseId,
            Title = Title,
            CanonicalDefinition = CanonicalDefinition,
            KeyPropositions = KeyPropositions
                .Where(kp => kp.Level <= level)
                .OrderBy(kp => kp.Order).ToList(),
            BoundaryConditions = BoundaryConditions
                .Where(bc => bc.Level <= level)
                .OrderBy(bc => bc.Order).ToList(),
            CommonMisconceptions = CommonMisconceptions
                .OrderBy(cm => cm.Order).ToList()
        };
    }

    public bool AreAllPropositionsCovered(ConversationAttempt attempt)
    {
        var coveredIds = attempt.GetCoveredPropositionIds();
        return KeyPropositions.All(kp => coveredIds.Contains(kp.Id));
    }
}
