using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Interfaces.Learning;

public interface IEnrolledCourseService
{
    Result<PagedResult<CourseDto>> GetAll(int learnerId, int page, int pageSize);
    Result<CourseDto> GetWithActiveUnits(int courseId, int learnerId);
    bool HasActiveEnrollment(int unitId, int learnerId);
    Result<KnowledgeUnitDto> GetUnit(int unitId, int learnerId);
}