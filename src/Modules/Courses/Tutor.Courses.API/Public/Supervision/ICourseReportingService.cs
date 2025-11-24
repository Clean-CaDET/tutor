using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Reports;

namespace Tutor.Courses.API.Public.Supervision;

public interface ICourseReportingService
{
    Result<List<CourseDto>> GetStartedCourses();
    Result<CourseDto> GetCourseWithGroupsAndUnits(int courseId);
    Result<CourseReportDto> RegenerateReport(int courseId, int learnerId);
    Result<CourseReportDto> GetReport(int courseId, int learnerId);
    Result<CourseReportDto> CreateReport(CourseReportDto report);
    Result<CourseReportDto> UpdateReport(CourseReportDto report);
}