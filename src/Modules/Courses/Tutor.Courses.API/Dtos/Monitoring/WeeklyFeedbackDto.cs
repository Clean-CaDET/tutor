using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.API.Dtos.Monitoring;

public class WeeklyFeedbackDto : Entity
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int LearnerId { get; set; }

    public int InstructorId { get; set; }
    public int InstructorName { get; private set; }
    public DateTime SelectedDate { get; set; }
    public int Semaphore { get; set; }
    public string? SemaphoreJustification { get; set; }

    public double AverageSatisfaction { get; set; }
    public double AchievedTaskPoints { get; set; }
    public double MaxTaskPoints { get; set; }
}