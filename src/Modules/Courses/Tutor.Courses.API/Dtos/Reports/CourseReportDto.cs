namespace Tutor.Courses.API.Dtos.Reports;

public class CourseReportDto
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int LearnerId { get; set; }
    public string Report { get; set; } = string.Empty;
    public int SatisfiedUnitPercent { get; set; }
    public int MeaningfulReflectionAnswerPercent { get; set; }
    public List<UnitReportDto>? UnitReports { get; set; }
    public List<FeedbackItemAggregateDto>? FeedbackItemAggregates { get; set; }
}