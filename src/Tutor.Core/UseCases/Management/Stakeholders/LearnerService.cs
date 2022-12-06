using FluentResults;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public class LearnerService : CrudService<Learner>, ILearnerService
{
    private readonly IUserRepository _userRepository;
    public LearnerService(ICrudRepository<Learner> crudRepository, IUserRepository userRepository) : base(crudRepository)
    {
        _userRepository = userRepository;
    }
    public Result<Learner> Register(Learner learner, string username, string password)
    {
        var user = _userRepository.Register(username, password, UserRole.Learner);
        learner.UserId = user.Id;
        // Warning: transactional consistency is not supported here (no rollback if Create fails).
        return Create(learner);
    }
}