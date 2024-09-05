using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Management;
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

    public Result<GroupDto> UpdateName(int groupId, string name)
    {
        var group = _groupRepository.Get(groupId);
        if (group == null) return Result.Fail(FailureCode.NotFound);

        group.Name = name;
        _groupRepository.Update(group);
        var result = UnitOfWork.Save();

        return result.IsFailed ? result : MapToDto(group);
    }
}