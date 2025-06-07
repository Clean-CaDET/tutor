namespace Tutor.Courses.API.Dtos.Reflections;

public class ReflectionQuestionDto
{
    public int Id { get; set; }
    public int Order { get; set; }
    public string Text { get; set; } = "";
    public QuestionCategory Category { get; set; }
    public ReflectionQuestionType Type { get; set; }
    public List<string>? Labels { get; set; }
}

public enum QuestionCategory
{
    Other,
    Satisfaction,
    Materials,
    System,
    Experience
}

public enum ReflectionQuestionType
{
    OpenEnded = 1,
    Slider = 2
}