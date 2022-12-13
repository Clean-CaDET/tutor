using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Knowledge;

public interface ICourseService
{
    Result<PagedResult<Course>> GetAll(bool includeArchived, int page, int pageSize);
    Result<Course> Create(Course course);
    Result Update(Course course);
    Result Delete(int id);
}