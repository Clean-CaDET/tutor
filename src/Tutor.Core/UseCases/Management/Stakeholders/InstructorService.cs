using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public class InstructorService : StakeholderService<Instructor>, IInstructorService
{
    public InstructorService(ICrudRepository<Instructor> crudRepository, IUnitOfWork unitOfWork, IUserRepository userRepository) 
        : base(crudRepository, unitOfWork, userRepository)
    {}
}