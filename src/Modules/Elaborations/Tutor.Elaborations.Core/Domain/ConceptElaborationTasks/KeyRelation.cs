using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class KeyRelation : Entity
{
    public int ConceptElaborationTaskId { get; private set; }
    public int SourceKeyPropositionId { get; internal set; }
    public int TargetKeyPropositionId { get; internal set; }
    public KeyProposition? SourceKeyProposition { get; internal set; }
    public KeyProposition? TargetKeyProposition { get; internal set; }
    public string Mechanism { get; private set; } = string.Empty;
}
