using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class CaseStudy : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
}
