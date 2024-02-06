using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class CaseStudy : ValueObject
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public CaseStudy(string name, string description)
    {
        Name = name;
        Description = description;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Description;
    }
}