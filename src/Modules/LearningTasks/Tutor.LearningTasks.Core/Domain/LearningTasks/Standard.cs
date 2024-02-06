using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class Standard : Entity
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public double MaxPoints { get; private set; }

    public void Update(Standard standard)
    {
        Name = standard.Name;
        Description = standard.Description;
        MaxPoints = standard.MaxPoints;
    }
}