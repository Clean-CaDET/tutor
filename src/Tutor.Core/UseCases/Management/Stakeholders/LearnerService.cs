using FluentResults;
using System.Collections.Generic;
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
        return _learnerRepository.GetByIndexes(indexes);
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
}