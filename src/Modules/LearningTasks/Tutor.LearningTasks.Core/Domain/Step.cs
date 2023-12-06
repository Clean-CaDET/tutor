using Tutor.BuildingBlocks.Core.Domain;
using Tutor.LearningTasks.Core.Domain.Activites;

namespace Tutor.LearningTasks.Core.Domain;

public class Step : Entity
{
    public int Order { get; private set; }
    public Activity Activity { get; private set; }
}
