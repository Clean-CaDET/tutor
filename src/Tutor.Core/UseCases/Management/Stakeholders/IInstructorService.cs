using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface IInstructorService
{
    Result<PagedResult<Instructor>> GetPaged(int page, int pageSize);
    Result<Instructor> Register(Instructor instructor, string username, string password);
    Result Update(Instructor entity);
    Result Delete(int id);
}