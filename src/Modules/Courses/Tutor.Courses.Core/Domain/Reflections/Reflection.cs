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

    public Reflection Clone(int unitId)
    {
        return new Reflection
        {
            UnitId = unitId,
            Order = Order,
            Name = Name,
            Questions = Questions.Select(q => q.Clone()).ToList(),
        };
    }
}