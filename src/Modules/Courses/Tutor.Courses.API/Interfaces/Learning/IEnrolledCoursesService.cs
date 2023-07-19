using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Interfaces.Learning;

public interface IEnrolledCoursesService
{
    Result<PagedResult<CourseDto>> GetAll(int learnerId, int page, int pageSize);
    Result<CourseDto> GetWithActiveUnits(int courseId, int learnerId);
}