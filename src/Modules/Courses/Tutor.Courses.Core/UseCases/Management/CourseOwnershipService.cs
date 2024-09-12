using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.Courses.Core.UseCases.Management;

public class CourseOwnershipService : ICourseOwnershipService
{
    private readonly IMapper _mapper;
    private readonly ICourseOwnershipRepository _courseOwnershipRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly IInternalInstructorService _instructorService;

    public CourseOwnershipService(IMapper mapper, ICourseOwnershipRepository courseOwnershipRepository,
        ICourseRepository courseRepository, ICoursesUnitOfWork unitOfWork, IInternalInstructorService instructorService)
    {
        _mapper = mapper;
        _courseOwnershipRepository = courseOwnershipRepository;
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
        _instructorService = instructorService;
    }

    public Result<List<InstructorDto>> GetOwners(int courseId)
    {
        var ids = _courseOwnershipRepository.GetOwnerIds(courseId);
        var result = _instructorService.GetMany(ids);

        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.Select(_mapper.Map<InstructorDto>).ToList();
    }
    
    public Result<CourseDto> AssignOwnership(int courseId, int instructorId)
    {
        var course = _courseRepository.Get(courseId);
        if(course == null) return Result.Fail(FailureCode.NotFound);

        var ownership = new CourseOwnership(course, instructorId);
        _courseOwnershipRepository.Create(ownership);
        var result = _unitOfWork.Save();

        if (result.IsFailed) return result;
        return Result.Ok(_mapper.Map<CourseDto>(course));
    }

    public Result RemoveOwnership(int courseId, int instructorId)
    {
        var ownership = _courseOwnershipRepository.GetByCourseAndInstructor(courseId, instructorId);
        if (ownership is null) return Result.Fail(FailureCode.NotFound);

        _courseOwnershipRepository.Delete(ownership);
        var result = _unitOfWork.Save();
        
        if (result.IsFailed) return result;
        return Result.Ok();
    }
}