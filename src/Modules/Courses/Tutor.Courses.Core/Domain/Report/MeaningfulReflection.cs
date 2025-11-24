using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Report;

public class MeaningfulReflection : ValueObject
{
    public int ReflectionId { get; }
    public DateTime Created { get; }
    public string Question { get; }
    public string Answer { get; }
    public MeaningfulReflection(int reflectionId, DateTime created, string question, string answer)
    {
        ReflectionId = reflectionId;
        Created = created;
        Question = question;
        Answer = answer;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ReflectionId;
        yield return Created;
        yield return Question;
        yield return Answer;
    }
}