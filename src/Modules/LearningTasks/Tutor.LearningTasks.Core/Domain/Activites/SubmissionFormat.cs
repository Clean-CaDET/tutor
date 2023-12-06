using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activites;

public class SubmissionFormat : ValueObject
{
    public string SubmissionGuidelines { get; private set; }
    public string AnswerValidation { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SubmissionGuidelines;
        yield return AnswerValidation;
    }
}
