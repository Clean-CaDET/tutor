using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activites;

public class Guidance : Entity
{
    public string DetailInfo { get; private set; }

    public Guidance(string detailInfo)
    {
        DetailInfo = detailInfo;
    }
}
