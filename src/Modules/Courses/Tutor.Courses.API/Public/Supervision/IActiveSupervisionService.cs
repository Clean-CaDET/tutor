using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Reflections;

namespace Tutor.Courses.API.Public.Supervision;

public interface IActiveSupervisionService
{
    Result<List<CourseDto>> GetActiveCourses();
    Result<List<GroupDto>> GetGroupedLearnersWithFeedback(int courseId);
    Result<List<ReflectionDto>> GetReflections(int learnerId, List<int>? reflectionIds);
}