using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class Standard : Entity
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public double MaxPoints { get; private set; }

    public Standard Clone()
    {
        return new Standard
        {
            Name = Name,
            Description = Description,
            MaxPoints = MaxPoints
        };
    }
}