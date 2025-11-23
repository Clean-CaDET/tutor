using Tutor.Courses.API.Dtos.Monitoring;

namespace Tutor.Courses.API.Dtos;

public class CourseAchievementsDto
{
    public int CourseId { get; set; }
    public int LearnerId { get; set; }
    public string Report { get; set; } = string.Empty;
    public int TotalSatisfiedPercent { get; set; }
    public int TotalMeaningfulReflectionAnswerPercent { get; set; }

    public List<UnitAchievementsDto> UnitAchievements { get; set; } = new();
    public List<WeeklyFeedbackDto> WeeklyFeedback { get; set; } = new();
}

public class UnitAchievementsDto
{
    public int UnitId { get; set; }
    public bool IsSatisfied { get; set; }
    public List<MeaningfulReflectionDto> MeaningfulReflections { get; set; } = new();
    public bool ContainsMeaningfulReflectionAnswer { get; set; }
}