namespace Tutor.Courses.API.Dtos.Monitoring;

public class WeeklyFeedbackItemDto
{
    public string Code { get; set; } = string.Empty;
    public int Value { get; set; }
    public string Label { get; set; } = string.Empty;
}