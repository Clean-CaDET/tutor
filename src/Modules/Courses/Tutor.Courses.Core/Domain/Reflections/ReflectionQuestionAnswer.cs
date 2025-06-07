using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Reflections;

public class ReflectionQuestionAnswer : ValueObject
{
    public int QuestionId { get; set; }
    public string Answer { get; set; } = "";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return QuestionId;
        yield return Answer;
    }
}