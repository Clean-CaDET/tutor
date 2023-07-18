using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Core.UseCases.Management;

public abstract class StakeholderService<TDomain> : CrudService<StakeholderAccountDto, TDomain> where TDomain : Stakeholder
{
    protected readonly IUserRepository UserRepository;

    protected StakeholderService(ICrudRepository<TDomain> crudRepository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository) 
        : base(crudRepository, unitOfWork, mapper)
    {
        UserRepository = userRepository;
    }

    public Result<StakeholderAccountDto> Register(StakeholderAccountDto entity, string username, string password, UserRole role)
    {
        UnitOfWork.BeginTransaction();

        if (UserRepository.Exists(username))
            return Result.Fail(FailureCode.DuplicateUsername);

        var user = UserRepository.Register(username, password, role);
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

        var user = UserRepository.Get(stakeholder.UserId);
        user.IsActive = !archive;

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(stakeholder);
    }

    public override Result Delete(int id)
    {
        var stakeholder = CrudRepository.Get(id);
        if (stakeholder is null) return Result.Fail(FailureCode.NotFound);
        CrudRepository.Delete(stakeholder);
        var user = UserRepository.Get(stakeholder.UserId);
        UserRepository.Delete(user);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}