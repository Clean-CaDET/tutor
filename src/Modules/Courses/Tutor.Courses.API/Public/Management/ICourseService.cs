using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Management;

public interface ICourseService
{
    Result<PagedResult<CourseDto>> GetAll(int page, int pageSize);
    Result<CourseDto> Create(CourseDto course);
    Result<CourseDto> Update(CourseDto course);
    Result<CourseDto> Archive(int id, bool archive);
    Result Delete(int id);
    Result<CourseDto> Clone(int courseId, CourseDto newCourse);
}