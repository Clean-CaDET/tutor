using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activites;

public class Subactivity : Entity
{
    public int Order { get; private set; }
    public Activity Activity { get; private set; }

    public Subactivity(int order, Activity activity)
    {
        Order = order;
        Activity = activity;
    }
}
