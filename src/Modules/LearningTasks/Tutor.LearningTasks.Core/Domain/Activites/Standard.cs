using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activites;

public class Standard : Entity
{
    public string Description { get; private set; }
    public int maxPoints { get; private set; }
}
