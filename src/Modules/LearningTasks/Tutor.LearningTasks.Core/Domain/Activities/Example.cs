using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activities;

public class Example : Entity
{
    public string? Description { get; private set; }
    public int ActivityId { get; private set; }

    private Example() { }

    public Example(string description, int activityId)
    {
        Description = description;
        ActivityId = activityId;
    }
}