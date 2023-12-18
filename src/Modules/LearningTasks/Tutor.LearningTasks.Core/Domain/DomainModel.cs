using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class DomainModel : Entity
{
    public string DetailInfo { get; private set; }
    public int LearningTaskId { get; private set; }

    public DomainModel(string detailInfo, int learningTaskId)
    {
        DetailInfo = detailInfo;
        LearningTaskId = learningTaskId;
    }
}

