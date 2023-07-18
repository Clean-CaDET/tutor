using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.Stakeholders.API.Interfaces.Management;

public interface IInstructorService
{
    Result<StakeholderAccountDto> Register(StakeholderAccountDto account);
    Result<PagedResult<StakeholderAccountDto>> GetPaged(int page, int pageSize);
    Result<StakeholderAccountDto> Update(StakeholderAccountDto entity);
    Result<StakeholderAccountDto> Archive(int id, bool archive);
    Result Delete(int id);
}