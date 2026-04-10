using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptRecords;

public class KeyRelation : Entity
{
    public int ConceptRecordId { get; private set; }
    public int SourceKeyPropositionId { get; private set; }
    public int TargetKeyPropositionId { get; private set; }
    public string Mechanism { get; private set; } = string.Empty;
    public PropositionLevel Level { get; private set; }
}
