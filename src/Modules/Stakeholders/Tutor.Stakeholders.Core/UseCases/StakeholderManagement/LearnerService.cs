using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Interfaces;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Core.UseCases.StakeholderManagement;

public class LearnerService : StakeholderService<Learner>, ILearnerService
{
    private readonly ILearnerRepository _learnerRepository;
    private readonly IUserRepository _userRepository;
    public LearnerService(IMapper mapper, ILearnerRepository learnerRepository, IStakeholdersUnitOfWork unitOfWork, IUserRepository userRepository)
        : base(learnerRepository, unitOfWork, mapper, userRepository)
    {
        _learnerRepository = learnerRepository;
        _userRepository = userRepository;
    }

    public Result<StakeholderAccountDto> Register(StakeholderAccountDto account)
    {
        var learner = MapToDomain(account);

        return Register(
            account,
            account.Index,
            account.Password,
            learner.LearnerType == LearnerType.Regular ? UserRole.Learner : UserRole.LearnerCommercial);
    }

    public Result<List<StakeholderAccountDto>> BulkRegister(List<StakeholderAccountDto> accounts)
    {
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

    private List<User> CreateUserAccounts(List<StakeholderAccountDto> accounts, List<Learner> learners)
    {
        return _userRepository.BulkRegister(
            accounts.Select(a => a.Index).ToList(),
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
        if (indexes == null) return Result.Fail(FailureCode.InvalidArgument);
        var result = _learnerRepository.GetByIndexes(indexes);
        return MapToDto(result);
    }
}