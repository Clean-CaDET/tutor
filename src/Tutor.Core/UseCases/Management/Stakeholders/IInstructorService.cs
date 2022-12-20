using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface IInstructorService
{
    Result<PagedResult<Instructor>> GetPaged(int page, int pageSize);
    Result<Instructor> Register(Instructor instructor, string username, string password);
    Result<Instructor> Update(Instructor entity);
    Result<Instructor> Archive(int id, bool archive);
    Result Delete(int id);
}