using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Management.Stakeholders;

public class InstructorService : CrudService<Instructor>, IInstructorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICrudRepository<Instructor> _instructorRepository;
    private readonly IUserRepository _userRepository;
    public InstructorService(IUnitOfWork unitOfWork, ICrudRepository<Instructor> crudRepository, IUserRepository userRepository) : base(crudRepository)
    {
        _unitOfWork = unitOfWork;
        _instructorRepository = crudRepository;
        _userRepository = userRepository;
    }
    public Result<Instructor> Register(Instructor instructor, string username, string password)
    {
        _unitOfWork.BeginTransaction();

        var user = _userRepository.Register(username, password, UserRole.Instructor);
        var result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }

        instructor.UserId = user.Id;
        var instructorResult = Create(instructor);
        result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }

        _unitOfWork.Commit();
        return instructorResult;
    }

    public Result<Instructor> Archive(int id, bool archive)
    {
        _unitOfWork.BeginTransaction();

        var instructor = _instructorRepository.Get(id);
        if (instructor == null) return Result.Fail(FailureCode.NotFound);
        instructor.IsArchived = archive;
        
        var user = _userRepository.Get(instructor.UserId);
        user.IsActive = !archive;

        var result = _unitOfWork.Save();
        if (result.IsFailed)
        {
            _unitOfWork.Rollback();
            return result;
        }

        _unitOfWork.Commit();
        return Result.Ok(instructor);
    }
}