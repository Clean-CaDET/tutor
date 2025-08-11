namespace Tutor.Courses.API.Dtos.Monitoring;

public class WeeklyFeedbackDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int LearnerId { get; set; }

    public int InstructorId { get; set; }
    public string? InstructorName { get; set; }
    public DateTime WeekEnd { get; set; }
    public int Semaphore { get; set; }
    public string? SemaphoreJustification { get; set; }
    public string? Opinions { get; set; }

    public double AverageSatisfaction { get; set; }
    public double AchievedTaskPoints { get; set; }
    public double MaxTaskPoints { get; set; }
    public List<int>? ReflectionIds { get; set; }
}