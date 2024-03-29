﻿using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;

namespace Tutor.Stakeholders.API.Public.Management;

public interface ILearnerService
{
    Result<StakeholderAccountDto> Register(StakeholderAccountDto account);
    Result<List<StakeholderAccountDto>> BulkRegister(List<StakeholderAccountDto> accounts);

    Result<PagedResult<StakeholderAccountDto>> GetPaged(int page, int pageSize);
    Result<PagedResult<StakeholderAccountDto>> GetByIndexes(string[] indexes);

    Result<StakeholderAccountDto> Update(StakeholderAccountDto learner);
    Result<StakeholderAccountDto> Archive(int id, bool archive);
    Result Delete(int id);
}