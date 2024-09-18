using FluentResults;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.Stakeholders.API.Internal;

public interface IInternalInstructorService
{
    Result<StakeholderAccountDto> Get(int instructorId);
    Result<List<StakeholderAccountDto>> GetMany(List<int> instructorIds);
}