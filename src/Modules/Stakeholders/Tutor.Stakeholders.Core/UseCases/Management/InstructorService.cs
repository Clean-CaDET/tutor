using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Stakeholders.API.Dtos;
using Tutor.Stakeholders.API.Interfaces;
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
}