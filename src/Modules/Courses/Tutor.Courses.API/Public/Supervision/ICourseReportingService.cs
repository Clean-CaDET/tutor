using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;

namespace Tutor.Courses.API.Public.Supervision;

public interface ICourseReportingService
{
    Result<List<CourseDto>> GetStartedCourses();
    Result<List<GroupDto>> GetGroupedLearners(int courseId);
}