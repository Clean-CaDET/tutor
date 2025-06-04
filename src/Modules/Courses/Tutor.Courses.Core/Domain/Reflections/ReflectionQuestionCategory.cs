using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Reflections;

public class ReflectionQuestionCategory : Entity
{
    public string Code { get; private set; } = "";
    public string Name { get; private set; } = "";
}