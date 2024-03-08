using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class SubmissionFormat : ValueObject
{
    public string Guidelines { get; private set; }
    public string AnswerValidation { get; private set; }

    public SubmissionFormat(string guidelines, string answerValidation)
    {
        Guidelines = guidelines;
        AnswerValidation = answerValidation;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Guidelines;
        yield return AnswerValidation;
    }
}