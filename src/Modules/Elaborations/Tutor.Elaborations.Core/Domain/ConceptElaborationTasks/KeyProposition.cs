using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class KeyProposition : Entity
{
    public int ConceptElaborationTaskId { get; private set; }
    public string Statement { get; private set; } = string.Empty;
}
