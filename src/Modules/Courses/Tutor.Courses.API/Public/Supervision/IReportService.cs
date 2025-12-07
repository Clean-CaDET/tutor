using FluentResults;
using Tutor.Courses.API.Dtos.Reports;

namespace Tutor.Courses.API.Public.Supervision;

public interface IReportService
{
    Result<List<CourseReportDto>> GetMany(int[] learnerIds);
    Result<CourseReportDto> Get(int courseId, int learnerId);
    Result<CourseReportDto> Create(CourseReportDto report);
    Result<CourseReportDto> Update(CourseReportDto report);
    Result<CourseReportDto> RegenerateAchievements(int courseId, int learnerId);
}