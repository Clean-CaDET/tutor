using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class DomainModel : ValueObject
{
    public string DetailInfo { get; private set; }

    public DomainModel(string detailInfo)
    {
        DetailInfo = detailInfo;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return DetailInfo;
    }
}

