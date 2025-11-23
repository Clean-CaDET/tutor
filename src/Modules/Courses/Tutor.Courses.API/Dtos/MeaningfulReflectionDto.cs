namespace Tutor.Courses.API.Dtos;

public class MeaningfulReflectionDto
{
    public int LearnerId { get; set; }
    public int ReflectionId { get; set; }
    public int UnitId { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}