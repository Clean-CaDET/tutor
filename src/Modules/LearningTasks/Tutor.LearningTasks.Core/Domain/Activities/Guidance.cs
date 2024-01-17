using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activities;

public class Guidance : ValueObject
{
    public string Description { get; private set; }

    public Guidance(string description)
    {
        Description = description;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Description;
    }
}