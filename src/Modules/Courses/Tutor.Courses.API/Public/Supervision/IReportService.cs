using FluentResults;
using Tutor.Courses.API.Dtos.Reports;

namespace Tutor.Courses.API.Public.Supervision;

public interface IReportService
{
    Result<CourseReportDto> Regenerate(int courseId, int learnerId);
    Result<CourseReportDto> Get(int courseId, int learnerId);
    Result<CourseReportDto> Create(CourseReportDto report);
    Result<CourseReportDto> Update(CourseReportDto report);
}