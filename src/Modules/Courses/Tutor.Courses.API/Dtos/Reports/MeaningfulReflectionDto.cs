namespace Tutor.Courses.API.Dtos.Reports;

public class MeaningfulReflectionDto
{
    public int ReflectionId { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}