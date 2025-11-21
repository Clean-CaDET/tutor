using Tutor.BuildingBlocks.Core.Domain;
using Tutor.Courses.Core.Domain.Reflections;

namespace Tutor.Courses.Core.Domain;

public class KnowledgeUnit : Entity
{
    public int CourseId { get; set; }
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string? Introduction { get; private set; }
    public string? Goals { get; private set; }
    public string? Guidelines { get; private set; }
    public int Order { get; private set; }
    public List<Reflection>? Reflections { get; private set; }

    internal KnowledgeUnit Clone()
    {
        return new KnowledgeUnit
        {
            Code = Code,
            Name = Name,
            Introduction = Introduction,
            Goals = Goals,
            Guidelines = Guidelines,
            Order = Order
        };
    }
}