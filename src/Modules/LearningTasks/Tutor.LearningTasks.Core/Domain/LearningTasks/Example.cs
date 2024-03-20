using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class Example : ValueObject
{
    public string Code { get; private set; }
    public string Url { get; private set; }

    public Example(string code, string url)
    {
        Code = code;
        Url = url;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Url;
    }
}