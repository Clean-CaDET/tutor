using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class ConceptElaborationTask : AggregateRoot
{
    public int UnitId { get; internal set; }
    public int Order { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public ConceptRecord ConceptRecord { get; private set; } = null!;

    private ConceptElaborationTask() { }

    public ConceptElaborationTask(int unitId, int order, string title, ConceptRecord conceptRecord)
    {
        UnitId = unitId;
        Order = order;
        Title = title;
        ConceptRecord = conceptRecord;
    }

    public void Update(ConceptElaborationTask incoming)
    {
        Title = incoming.Title;
        Order = incoming.Order;
        ConceptRecord.Update(incoming.ConceptRecord);
    }
}
