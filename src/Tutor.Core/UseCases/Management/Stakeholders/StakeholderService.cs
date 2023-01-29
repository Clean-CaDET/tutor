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
    public Result<T> Register(T entity, string username, string password)
    {
        _unitOfWork.BeginTransaction();

        var user = _userRepository.Register(username, password, UserRole.Learner);
        var result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }
        entity.UserId = user.Id;
        var registerResult = Create(entity);
        result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }

        _unitOfWork.Commit();
        return registerResult;
    }

    public Result<T> Archive(int id, bool archive)
    {
        var stakeholder = _crudRepository.Get(id);
        if (stakeholder is null) return Result.Fail(FailureCode.NotFound);

        stakeholder.IsArchived = archive;

        var user = _userRepository.Get(stakeholder.UserId);
        user.IsActive = !archive;

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(stakeholder);
    }

    public override Result<T> Update(T entity)
    {
        var dbStakeholder = _crudRepository.Get(entity.Id);
        if (dbStakeholder is null) return Result.Fail(FailureCode.NotFound);
        var user = _userRepository.Get(dbStakeholder.UserId);
        entity.UserId = user.Id;

        _crudRepository.Update(dbStakeholder, entity);
        user.Username = entity.Email;

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return entity;
    }

    public override Result Delete(int id)
    {
        var stakeholder = _crudRepository.Get(id);
        if (stakeholder is null) return Result.Fail(FailureCode.NotFound);
        _crudRepository.Delete(stakeholder);
        var user = _userRepository.Get(stakeholder.UserId);
        _userRepository.Delete(user);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }

}