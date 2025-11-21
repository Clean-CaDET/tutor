using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Dtos.Reflections;

namespace Tutor.Courses.API.Dtos;

public class CourseAchievementsDto
{
    public int CourseId { get; set; }
    public int LearnerId { get; set; }
    public string Report { get; set; } = string.Empty;

    public List<ReflectionAnswerDto> ReflectionAnswers { get; set; } = new();
    public int ReflectionsAnsweredPercent { get; set; }

    public List<WeeklyFeedbackDto> WeeklyFeedback { get; set; } = new();

    public int TaskSatisfiedPercent { get; set; }
    public int KcSatisfiedPercent { get; set; }
}