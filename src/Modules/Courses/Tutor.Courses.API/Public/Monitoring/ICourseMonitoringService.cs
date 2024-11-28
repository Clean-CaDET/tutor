using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;

namespace Tutor.Courses.API.Public.Monitoring;

public interface ICourseMonitoringService
{
    Result<List<CourseDto>> GetActiveCourses();
    Result<List<GroupDto>> GetGroupFeedback(int courseId);
    Result<List<CourseDto>> GetOwnedActiveCourses(int instructorId);
    Result<List<GroupDto>> GetOwnedGroupFeedback(int courseId, int instructorId);
}