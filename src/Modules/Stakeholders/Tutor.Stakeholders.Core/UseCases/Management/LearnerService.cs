﻿using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Internal;
using Tutor.Stakeholders.API.Public.Management;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Core.UseCases.Management;

public class LearnerService : StakeholderService<Learner>, ILearnerService, IInternalLearnerService
{
    private readonly ILearnerRepository _learnerRepository;
    public LearnerService(IMapper mapper, ILearnerRepository learnerRepository, IStakeholdersUnitOfWork unitOfWork, IUserRepository userRepository)
        : base(learnerRepository, unitOfWork, mapper, userRepository)
    {
        _learnerRepository = learnerRepository;
    }

    public Result<StakeholderAccountDto> Register(StakeholderAccountDto account)
    {
        if (IsInvalidLearnerType(account.LearnerType)) return Result.Fail(FailureCode.InvalidArgument);
        
        var learner = MapToDomain(account);

        return Register(
            account,
            account.Index,
            account.Password,
            learner.LearnerType == LearnerType.Regular ? UserRole.Learner : UserRole.LearnerCommercial);
    }

    private static bool IsInvalidLearnerType(string learnerType)
    {
        return learnerType != "Regular" && learnerType != "Commercial";
    }

    public Result<List<StakeholderAccountDto>> BulkRegister(List<StakeholderAccountDto> accounts)
    {
        if(HasMixedLearnerTypes(accounts)) return Result.Fail(FailureCode.InvalidArgument);

        var learners = MapToDomain(accounts);

        UnitOfWork.BeginTransaction();

        var users = CreateUserAccounts(accounts, learners);
        var result = UnitOfWork.Save();

        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        CreateLearners(learners, users);

        result = UnitOfWork.Save();
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        UnitOfWork.Commit();
        return MapToDto(learners);
    }

    private static bool HasMixedLearnerTypes(List<StakeholderAccountDto> accounts)
    {
        var learnerTypes = accounts.Select(a => a.LearnerType).Distinct().ToList();
        return learnerTypes.Count > 1 || IsInvalidLearnerType(learnerTypes[0]);
    }

    private List<User> CreateUserAccounts(List<StakeholderAccountDto> accounts, List<Learner> learners)
    {
        return UserRepository.BulkRegister(
            accounts.Select(a => a.Index).ToList()!,
            accounts.Select(a => a.Password).ToList(),
            learners.First().LearnerType == LearnerType.Regular ? UserRole.Learner : UserRole.LearnerCommercial);
    }

    private void CreateLearners(List<Learner> learners, List<User> users)
    {
        foreach (var learner in learners)
        {
            var user = users.Find(u => u.Username.Equals(learner.Index));
            if (user == null) continue;
            learner.UserId = user.Id;
        }

        _learnerRepository.BulkCreate(learners);
    }

    public Result<PagedResult<StakeholderAccountDto>> GetByIndexes(string[] indexes)
    {
        if (indexes == null || indexes.Length == 0) return Result.Fail(FailureCode.InvalidArgument);
        var result = _learnerRepository.GetByIndexes(indexes);
        return MapToDto(result);
    }

    public override Result<StakeholderAccountDto> Update(StakeholderAccountDto learner)
    {
        var dbStakeholder = CrudRepository.Get(learner.Id);
        if (dbStakeholder is null) return Result.Fail(FailureCode.NotFound);
        var user = UserRepository.Get(dbStakeholder.UserId);
        learner.UserId = user.Id;

        var updatedLearner = CrudRepository.Update(dbStakeholder, MapToDomain(learner));
        user.Username = learner.Index!;

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(updatedLearner);
    }
}