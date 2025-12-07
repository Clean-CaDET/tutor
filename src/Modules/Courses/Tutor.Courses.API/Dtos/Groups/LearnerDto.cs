using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Dtos.Reports;

namespace Tutor.Courses.API.Dtos.Groups;

public class LearnerDto
{
    public int Id { get; set; }
    public string Index { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<WeeklyFeedbackDto>? WeeklyFeedback { get; set; }
    public List<CourseReportDto>? Reports { get; set; }
}