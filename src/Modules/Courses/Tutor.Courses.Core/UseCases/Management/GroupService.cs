using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Management;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Management;

public class GroupService: CrudService<GroupDto, LearnerGroup>, IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IMapper mapper, IGroupRepository groupRepository, ICoursesUnitOfWork unitOfWork) : base(groupRepository, unitOfWork, mapper)
    {
        _groupRepository = groupRepository;
    }

    public Result<List<GroupDto>> GetByCourse(int courseId)
    {
        var result = _groupRepository.GetCourseGroups(courseId);
        return MapToDto(result);
    }
}