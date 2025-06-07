namespace Tutor.Courses.API.Dtos.Reflections;

public class ReflectionAnswerDto
{
    public int Id { get; set; }
    public int LearnerId { get; set; }
    public int ReflectionId { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public List<ReflectionQuestionAnswerDto> Answers { get; set; } = new();
}