using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class SubmissionFormat : ValueObject
{
    public SubmissionType Type { get; private set; }
    public string AnswerValidation { get; private set; }
    public string Guidelines { get; private set; }

    public SubmissionFormat(SubmissionType type, string answerValidation, string guidelines)
    {
        Type = type;
        AnswerValidation = answerValidation;
        Guidelines = guidelines;        
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Type;
        yield return AnswerValidation;
        yield return Guidelines;
    }
}

public enum SubmissionType
{
    Text, Link, Code
}