using FluentResults;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public class InstructorService : CrudService<Instructor>, IInstructorService
{
    private readonly IUserRepository _userRepository;
    public InstructorService(ICrudRepository<Instructor> crudRepository, IUserRepository userRepository) : base(crudRepository)
    {
        _userRepository = userRepository;
    }
    public Result<Instructor> Register(Instructor instructor, string username, string password)
    {
        var user = _userRepository.Register(username, password, UserRole.Instructor);
        instructor.UserId = user.Id;
        // Warning: transactional consistency is not supported here (no rollback if Create fails).
        return Create(instructor);
    }
}