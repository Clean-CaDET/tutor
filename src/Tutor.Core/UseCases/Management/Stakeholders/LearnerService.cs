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

    public Result<PagedResult<Learner>> GetByIndexes(string[] indexes)
    {
        if (indexes == null) return Result.Fail(FailureCode.InvalidArgument);
        return _learnerRepository.GetByIndexes(indexes);
    }

    public Result<List<Learner>> BulkRegister(List<Learner> learners, List<string> usernames, List<string> passwords, UserRole role)
    {
        UnitOfWork.BeginTransaction();

        var users = _userRepository.BulkRegister(usernames, passwords, role);
        var result = UnitOfWork.Save();
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        foreach (var learner in learners)
        {
            var user = users.Find(u => u.Username.Equals(learner.Index));
            if (user == null) continue;
            learner.UserId = user.Id;
        }
        _learnerRepository.BulkCreate(learners);
        result = UnitOfWork.Save();
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        UnitOfWork.Commit();
        return Result.Ok(learners);
    }
}