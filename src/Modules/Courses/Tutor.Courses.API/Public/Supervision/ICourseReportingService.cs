using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Supervision;

public interface ICourseReportingService
{
    Result<List<CourseDto>> GetStartedCourses();
    Result<CourseDto> GetCourseWithGroupsAndUnits(int courseId);
    Result<CourseAchievementsDto> GetAchievements(int courseId, int learnerId);
}