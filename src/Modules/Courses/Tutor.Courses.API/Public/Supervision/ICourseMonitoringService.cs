using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Reflections;

namespace Tutor.Courses.API.Public.Supervision;

public interface ICourseMonitoringService
{
    Result<List<CourseDto>> GetActiveCourses();
    Result<List<GroupDto>> GetGroupedLearnersWithFeedback(int courseId);
    Result<List<ReflectionDto>> GetReflections(int learnerId, List<int>? reflectionIds);

    Result<List<CourseDto>> GetStartedCourses();
    Result<CourseDto> GetCourseWithGroupsAndUnits(int courseId);
    Result<CourseAchievementsDto> GetAchievements(int courseId, int learnerId, AchievementsRequestDto ids);
}