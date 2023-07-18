using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Interfaces.Management;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Core.UseCases.Management;

public class InstructorService : StakeholderService<Instructor>, IInstructorService
{
    public InstructorService(IMapper mapper,
        ICrudRepository<Instructor> crudRepository, IStakeholdersUnitOfWork unitOfWork, IUserRepository userRepository)
        : base(crudRepository, unitOfWork, mapper, userRepository) { }

    public Result<StakeholderAccountDto> Register(StakeholderAccountDto account)
    {
        return Register(
            account,
            account.Email,
            account.Password,
            UserRole.Instructor);
    }

    public override Result<StakeholderAccountDto> Update(StakeholderAccountDto entity)
    {
        var dbStakeholder = CrudRepository.Get(entity.Id);
        if (dbStakeholder is null) return Result.Fail(FailureCode.NotFound);
        var user = UserRepository.Get(dbStakeholder.UserId);
        entity.UserId = user.Id;

        CrudRepository.Update(dbStakeholder, MapToDomain(entity));
        user.Username = entity.Email;

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return entity;
    }
}