using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface ICourseService
{
    Result<PagedResult<Course>> GetAll(bool includeArchived, int page, int pageSize);
    Result<Course> Create(Course course);
    Result<Course> Update(Course course);
    Result<Course> Archive(int id, bool archive);
    Result Delete(int id);
}