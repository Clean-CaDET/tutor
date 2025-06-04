namespace Tutor.Courses.API.Dtos.Reflections;

public class ReflectionQuestionDto
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string Text { get; set; } = "";
    public ReflectionQuestionCategoryDto? Category { get; set; }
    public ReflectionQuestionType Type { get; set; }
    public List<string>? Labels { get; set; }
}

public enum ReflectionQuestionType
{
    OpenEnded = 1,
    Slider4 = 2
}