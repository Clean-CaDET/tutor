using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public class StakeholderService<T> : CrudService<T>, IStakeholderService<T> where T : Stakeholder
{
    private readonly IUserRepository _userRepository;

    public StakeholderService(ICrudRepository<T> crudRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) 
        : base(crudRepository, unitOfWork)
    {
        _userRepository = userRepository;
    }
    public Result<T> Register(T stakeholder, string username, string password)
    {
        _unitOfWork.BeginTransaction();

        var user = _userRepository.Register(username, password, UserRole.Learner);
        var result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }
        stakeholder.UserId = user.Id;
        var learnerResult = Create(stakeholder);
        result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }

        _unitOfWork.Commit();
        return learnerResult;
    }

    public Result<T> Archive(int id, bool archive)
    {
        _unitOfWork.BeginTransaction();

        var stakeholderResult = Get(id);
        if (stakeholderResult.IsFailed) return stakeholderResult;
        var stakeholder = (Stakeholder)stakeholderResult.Value;
        stakeholder.IsArchived = archive;

        var user = _userRepository.Get(stakeholder.UserId);
        user.IsActive = !archive;

        var result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }

        _unitOfWork.Commit();
        return Result.Ok((T)stakeholder);
    }

    public override Result Delete(int id)
    {
        _unitOfWork.BeginTransaction();

        _crudRepository.Delete(id);
        _userRepository.Delete(id);

        var result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }

        _unitOfWork.Commit();
        return Result.Ok();
    }

}