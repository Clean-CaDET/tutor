using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class Step : ValueObject
{
    public int Order { get; private set; }
    public int ActivityId { get; private set; }
    public string ActivityName { get; private set; }

    public Step(int order, int activityId, string activityName)
    {
        Order = order;
        ActivityId = activityId;
        ActivityName = activityName;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}
