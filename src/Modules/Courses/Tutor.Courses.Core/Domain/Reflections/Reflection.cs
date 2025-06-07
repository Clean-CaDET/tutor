using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Reflections;

public class Reflection : Entity
{
    public int UnitId { get; private set; }
    public int Order { get; private set; }
    public string Name { get; private set; } = "";
    public List<ReflectionQuestion> Questions { get; private set; } = new();
    public List<ReflectionAnswer> Submissions { get; private set; } = new();

    public void Update(Reflection updatedReflection)
    {
        Name = updatedReflection.Name;
        Order = updatedReflection.Order;
        Questions = updatedReflection.Questions;
    }
}