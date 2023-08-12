using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Authoring;

public interface IOwnedCourseService
{
    Result<List<CourseDto>> GetAll(int instructorId);
    Result<CourseDto> GetWithUnits(int courseId, int instructorId);
    Result<CourseDto> Update(CourseDto course, int instructorId);
}