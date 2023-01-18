using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public class LearnerService : CrudService<Learner>, ILearnerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILearnerRepository _learnerRepository;
    private readonly IUserRepository _userRepository;
    public LearnerService(IUnitOfWork unitOfWork, ILearnerRepository learnerRepository, IUserRepository userRepository) : base(learnerRepository)
    {
        _unitOfWork = unitOfWork;
        _learnerRepository = learnerRepository;
        _userRepository = userRepository;
    }

    public Result<PagedResult<Learner>> GetByIndexes(string[] indexes)
    {
        return _learnerRepository.GetByIndexes(indexes);
    }

    public Result<Learner> Register(Learner learner, string username, string password)
    {
        _unitOfWork.BeginTransaction();

        var user = _userRepository.Register(username, password, UserRole.Learner);
        var result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }
        learner.UserId = user.Id;
        var learnerResult = Create(learner);
        result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }

        _unitOfWork.Commit();
        return learnerResult;
    }

    public Result BulkRegister(List<Learner> learners, List<string> usernames, List<string> passwords)
    {
        var users = _userRepository.BulkRegister(usernames, passwords, UserRole.Learner);
        foreach (var learner in learners)
        {
            var user = users.Find(u => u.Username.Equals(learner.Index));
            if (user == null) continue;
            learner.UserId = user.Id;
        }
        // Warning: transactional consistency is not supported here (no rollback if Create fails).
        _learnerRepository.BulkCreate(learners);

        return Result.Ok();
    }

    public Result<Learner> Archive(int id, bool archive)
    {
        var learner = _learnerRepository.Get(id);
        if (learner == null) return Result.Fail(FailureCode.NotFound);
        // Warning: Explicit account (User) deactivation is missing.
        learner.IsArchived = archive;
        _learnerRepository.Update(learner);
        return Result.Ok(learner);
    }
}