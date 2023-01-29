using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public interface IInstructorService : IStakeholderService<Instructor>
{
    Result<PagedResult<Instructor>> GetPaged(int page, int pageSize);
}