using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activities;

public class Example : ValueObject
{
    public string Code { get; private set; }
    public string Description { get; private set; }

    public Example(string code, string description)
    {
        Code = code;
        Description = description;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Description;
    }
}