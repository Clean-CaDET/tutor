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
    public Result<T> Register(T entity, string username, string password, UserRole role)
    {
        UnitOfWork.BeginTransaction();

        if (_userRepository.Exists(username))
            return Result.Fail(FailureCode.DuplicateUsername);

        var user = _userRepository.Register(username, password, role);
        var result = UnitOfWork.Save();
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }
        entity.UserId = user.Id;
        var registerResult = Create(entity);
        if (result.IsFailed)
        {
            UnitOfWork.Rollback();
            return result;
        }

        UnitOfWork.Commit();
        return registerResult;
    }

    public Result<T> Archive(int id, bool archive)
    {
        var stakeholder = CrudRepository.Get(id);
        if (stakeholder is null) return Result.Fail(FailureCode.NotFound);

        stakeholder.IsArchived = archive;

        var user = _userRepository.Get(stakeholder.UserId);
        user.IsActive = !archive;

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok(stakeholder);
    }

    public override Result<T> Update(T entity)
    {
        var dbStakeholder = CrudRepository.Get(entity.Id);
        if (dbStakeholder is null) return Result.Fail(FailureCode.NotFound);
        var user = _userRepository.Get(dbStakeholder.UserId);
        entity.UserId = user.Id;

        CrudRepository.Update(dbStakeholder, entity);
        user.Username = entity.Email;

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return entity;
    }

    public override Result Delete(int id)
    {
        var stakeholder = CrudRepository.Get(id);
        if (stakeholder is null) return Result.Fail(FailureCode.NotFound);
        CrudRepository.Delete(stakeholder);
        var user = _userRepository.Get(stakeholder.UserId);
        _userRepository.Delete(user);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}