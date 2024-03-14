using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class SubmissionFormat : ValueObject
{
    public SubmissionType Type { get; private set; }
    public string ValidationRule { get; private set; }
    public string Guidelines { get; private set; }

    public SubmissionFormat(SubmissionType type, string validationRule, string guidelines)
    {
        Type = type;
        ValidationRule = validationRule;
        Guidelines = guidelines;        
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return ValidationRule;
        yield return Guidelines;
    }
}

public enum SubmissionType
{
    Text, Link, Code
}