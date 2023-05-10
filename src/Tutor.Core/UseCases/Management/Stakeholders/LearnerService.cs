using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public class LearnerService : StakeholderService<Learner>, ILearnerService
{
    private readonly ILearnerRepository _learnerRepository;
    private readonly IUserRepository _userRepository;
    public LearnerService(ILearnerRepository learnerRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) 
        : base(learnerRepository, unitOfWork, userRepository)
    {
        _learnerRepository = learnerRepository;
        _userRepository = userRepository;
    }

    public Result<(PagedResult<Learner> learners, List<UserRole> roles)> GetPagedWithRole(int page, int pageSize)
    {
        var learners = _learnerRepository.GetPaged(page, pageSize);
        var roles = _userRepository.GetByNames(learners.Results.Select(l => l.Index).ToList()).Select(u => u.Role).ToList();
        return (learners, roles);
    }

    public Result<PagedResult<Learner>> GetByIndexes(string[] indexes)
    {
        if (indexes == null) return Result.Fail(FailureCode.InvalidArgument);
        return _learnerRepository.GetByIndexes(indexes);
    }

    public Result<(List<Learner> existingLearners, List<Learner> newLearners)> BulkRegister(List<Learner> learners, List<string> usernames, List<string> passwords, string learnerType)
    {
        var result = GetRole(learnerType, out UserRole role);
        if (result.IsFailed) return result;

        result = CheckDuplicateUsernames(usernames);
        if (result.IsFailed) return result;

        UnitOfWork.BeginTransaction();

        var (existingLearners, newLearners) = FindExistingAndNewLearners(learners, usernames);
        var newUsernames = newLearners.Select(l => l.Index).ToList();

        var newUsers = _userRepository.BulkRegister(newUsernames, passwords, role);
        result = UnitOfWork.Save();
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        foreach (var learner in newLearners)
        {
            var user = newUsers.Find(u => u.Username.Equals(learner.Index));
            learner.UserId = user.Id;
        }

        _learnerRepository.BulkCreate(newLearners);
        result = UnitOfWork.Save();
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        UnitOfWork.Commit();
        return Result.Ok((existingLearners, newLearners));
    }

    private static Result CheckDuplicateUsernames(List<string> usernames)
    {
        var anyDuplicate = usernames.GroupBy(u => u).Any(g => g.Count() > 1);
        return anyDuplicate ? Result.Fail(FailureCode.DuplicateUsername) : Result.Ok();
    }

    private (List<Learner> existingLearners, List<Learner> newLearners) FindExistingAndNewLearners(List<Learner> learners, List<string> usernames)
    {
        var existingUsers = _userRepository.GetByNames(usernames);

        var existingLearners = new List<Learner>();
        var newLearners = new List<Learner>();
        foreach (var learner in learners)
        {
            var user = existingUsers.Find(u => u.Username.Equals(learner.Index));
            if (user == null) newLearners.Add(learner);
            else existingLearners.Add(learner);
        }

        return (existingLearners, newLearners);
    }
}