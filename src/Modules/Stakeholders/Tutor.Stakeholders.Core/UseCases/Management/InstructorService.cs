using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Internal;
using Tutor.Stakeholders.API.Public.Management;
using Tutor.Stakeholders.Core.Domain;
using Tutor.Stakeholders.Core.Domain.RepositoryInterfaces;

namespace Tutor.Stakeholders.Core.UseCases.Management;

public class InstructorService : StakeholderService<Instructor>, IInstructorService, IInternalInstructorService
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

    public override Result<StakeholderAccountDto> Update(StakeholderAccountDto instructor)
    {
        var dbStakeholder = CrudRepository.Get(instructor.Id);
        if (dbStakeholder is null) return Result.Fail(FailureCode.NotFound);
        var user = UserRepository.Get(dbStakeholder.UserId);
        instructor.UserId = user.Id;

        var updatedInstructor = CrudRepository.Update(dbStakeholder, MapToDomain(instructor));
        user.Username = instructor.Email;

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(updatedInstructor);
    }
}