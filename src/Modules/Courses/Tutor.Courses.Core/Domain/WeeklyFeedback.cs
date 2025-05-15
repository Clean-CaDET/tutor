using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class WeeklyFeedback : Entity
{
    public int CourseId { get; private set; }
    public int LearnerId { get; private set; }

    public int InstructorId { get; private set; }
    public string? InstructorName { get; private set; }
    public DateTime WeekEnd { get; private set; }
    public ProgressSemaphore Semaphore { get; private set; }
    public string? SemaphoreJustification { get; private set; }
    public string? Opinions { get; private set; }

    public double AverageSatisfaction { get; private set; }
    public double AchievedTaskPoints { get; set; }
    public double MaxTaskPoints { get; set; }
}

public enum ProgressSemaphore
{
    Red = 1, Yellow = 2, Green = 3
}