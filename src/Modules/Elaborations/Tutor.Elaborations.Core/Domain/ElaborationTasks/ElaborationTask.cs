using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.Domain.ElaborationTasks;

public class ElaborationTask : Entity
{
    public int ConceptRecordId { get; private set; }
    public int UnitId { get; internal set; }
    public PropositionLevel ExpectedLevel { get; private set; }
    public int Order { get; private set; }
}
