using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activities;

public class Subactivity : ValueObject
{
    public int Order { get; private set; }
    public int ChildId { get; private set; }

    public Subactivity(int order, int childId)
    {
        Order = order;
        ChildId = childId;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Order;
        yield return ChildId;
    }
}