using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class Standard : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int MaxPoints { get; private set; }

    public Standard(string name, string description, int maxPoints)
    {
        Name = name;
        Description = description;
        MaxPoints = maxPoints;
    }
}