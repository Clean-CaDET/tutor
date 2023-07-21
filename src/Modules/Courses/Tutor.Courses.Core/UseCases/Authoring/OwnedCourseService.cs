using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Authoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Authoring;

public class OwnedCourseService : BaseService<CourseDto, Course>, IOwnedCourseService
{
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;

    public OwnedCourseService(IMapper mapper, IOwnedCourseRepository ownedCourseRepository, ICourseRepository courseRepository, ICoursesUnitOfWork unitOfWork): base(mapper)
    {
        _ownedCourseRepository = ownedCourseRepository;
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<List<CourseDto>> GetAll(int instructorId)
    {
        var result = _ownedCourseRepository.GetAll(instructorId);
        return MapToDto(result);
    }

    public Result<CourseDto> GetWithUnits(int courseId, int instructorId)
    {
        if(!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var result = _courseRepository.GetWithUnits(courseId);
        return MapToDto(result);
    }

    public Result<CourseDto> Update(CourseDto course, int instructorId)
    {
        if(!_ownedCourseRepository.IsCourseOwner(course.Id, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var updatedCourse = _courseRepository.Update(MapToDomain(course));
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return MapToDto(updatedCourse);
    }
}