using FluentResults;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.Stakeholders.API.Internal;

public interface IInternalLearnerService
{
    Result<List<StakeholderAccountDto>> GetMany(List<int> learnerIds);
}