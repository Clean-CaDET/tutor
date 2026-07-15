using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class ConceptElaborationTask : AggregateRoot
{
    public int UnitId { get; internal set; }
    public int Order { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public ConceptRecord? ConceptRecord { get; private set; }

    private ConceptElaborationTask() { }

    public ConceptElaborationTask(int unitId, int order, string title, string description, ConceptRecord conceptRecord)
    {
        UnitId = unitId;
        Order = order;
        Title = title;
        Description = description;
        ConceptRecord = conceptRecord;
    }

    public void Update(ConceptElaborationTask incoming)
    {
        if (incoming.ConceptRecord == null || ConceptRecord == null)
            throw new InvalidOperationException("ConceptRecord cannot be null when updating.");
        Title = incoming.Title;
        Description = incoming.Description;
        Order = incoming.Order;
        ConceptRecord.Update(incoming.ConceptRecord);
    }
}
