using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class CommonMisconception : Entity
{
    public int ConceptElaborationTaskId { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public string Correction { get; private set; } = string.Empty;
}
