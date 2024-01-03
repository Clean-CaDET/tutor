using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activities;

public class Guidance : ValueObject
{
    public string DetailInfo { get; private set; }

    public Guidance(string detailInfo)
    {
        DetailInfo = detailInfo;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return DetailInfo;
    }
}