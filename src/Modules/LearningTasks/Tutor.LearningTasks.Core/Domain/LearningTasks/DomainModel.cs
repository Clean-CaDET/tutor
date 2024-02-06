using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class DomainModel : ValueObject
{
    public string Description { get; private set; }

    public DomainModel(string description)
    {
        Description = description;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Description;
    }
}