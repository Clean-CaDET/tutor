using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Core.UseCases.StakeholderManagement;

public class StakeholderService<TDomain> : CrudService<StakeholderAccountDto, TDomain> where TDomain : Stakeholder
{
    private readonly IUserRepository _userRepository;

    public StakeholderService(ICrudRepository<TDomain> crudRepository, IStakeholdersUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository) 
        : base(crudRepository, unitOfWork, mapper)
    {
        _userRepository = userRepository;
    }
    public Result<StakeholderAccountDto> Register(StakeholderAccountDto entity, string username, string password, UserRole role)
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

    public Result<StakeholderAccountDto> Archive(int id, bool archive)
    {
        var stakeholder = CrudRepository.Get(id);
        if (stakeholder is null) return Result.Fail(FailureCode.NotFound);

        stakeholder.IsArchived = archive;

        var user = _userRepository.Get(stakeholder.UserId);
        user.IsActive = !archive;

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(stakeholder);
    }

    public override Result<StakeholderAccountDto> Update(StakeholderAccountDto entity)
    {
        var dbStakeholder = CrudRepository.Get(entity.Id);
        if (dbStakeholder is null) return Result.Fail(FailureCode.NotFound);
        var user = _userRepository.Get(dbStakeholder.UserId);
        entity.UserId = user.Id;

        CrudRepository.Update(dbStakeholder, MapToDomain(entity));
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