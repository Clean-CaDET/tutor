using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Management;

public interface ICourseOwnershipService
{
    Result<List<InstructorDto>> GetOwners(int courseId);
    Result<CourseDto> AssignOwnership(int courseId, int instructorId);
    Result RemoveOwnership(int courseId, int instructorId);
}