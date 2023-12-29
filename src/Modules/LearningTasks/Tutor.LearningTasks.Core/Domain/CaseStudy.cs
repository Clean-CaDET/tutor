using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class CaseStudy : AggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public CaseStudy(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
