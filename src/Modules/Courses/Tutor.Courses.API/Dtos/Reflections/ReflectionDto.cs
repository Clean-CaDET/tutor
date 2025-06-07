namespace Tutor.Courses.API.Dtos.Reflections;

public class ReflectionDto
{
    public int Id { get; set; }
    public int UnitId { get; set; }
    public int Order { get; set; }
    public string Name { get; set; } = "";
    public List<ReflectionQuestionDto> Questions { get; set; } = new();
    public List<ReflectionAnswerDto>? Submissions { get; set; }
}