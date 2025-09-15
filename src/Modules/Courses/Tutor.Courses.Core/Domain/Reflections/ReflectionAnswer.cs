using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Reflections;

public class ReflectionAnswer : Entity
{
    public int LearnerId { get; private set; }
    public int ReflectionId { get; private set; }
    public DateTime Created { get; private set; }
    public List<ReflectionQuestionAnswer> Answers { get; private set; } = new();

    public void Update(ReflectionAnswer answer)
    {
        Created = answer.Created;
        Answers = answer.Answers;
    }
}