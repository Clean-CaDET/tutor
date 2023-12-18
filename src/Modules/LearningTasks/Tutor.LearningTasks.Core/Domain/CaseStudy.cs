using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class CaseStudy : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int LearningTaskId { get; private set; }

    public CaseStudy(string name, string description, int learningTaskId)
    {
        Name = name;
        Description = description;
        LearningTaskId = learningTaskId;
    }
}
