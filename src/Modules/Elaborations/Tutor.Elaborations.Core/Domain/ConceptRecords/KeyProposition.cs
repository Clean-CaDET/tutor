using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptRecords;

public class KeyProposition : Entity
{
    public int ConceptRecordId { get; private set; }
    public string Statement { get; private set; } = string.Empty;
    public PropositionLevel Level { get; private set; }
    public int Order { get; private set; }
}
