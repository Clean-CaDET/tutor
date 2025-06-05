using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain.Reflections;

public class ReflectionQuestion : Entity
{
    public int ReflectionId { get; private set; }
    public int Order { get; private set; }
    public string Text { get; private set; } = "";
    public ReflectionQuestionCategory? Category { get; private set; }
    public ReflectionQuestionType Type { get; private set; }
    public List<string>? Labels { get; private set; }
}

public enum ReflectionQuestionType
{
    OpenEnded = 1,
    Slider = 2
}