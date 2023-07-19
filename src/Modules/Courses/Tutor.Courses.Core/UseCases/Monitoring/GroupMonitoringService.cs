using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Monitoring;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class GroupMonitoringService : IGroupMonitoringService
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public GroupMonitoringService(IMapper mapper, IGroupRepository groupRepository, 
        IOwnedCourseRepository ownedCourseRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<List<GroupDto>> GetCourseGroups(int instructorId, int courseId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var groups = _groupRepository.GetCourseGroups(courseId);
        return groups.Select(_mapper.Map<GroupDto>).ToList();
    }

    public Result<PagedResult<LearnerDto>> GetLearners(int instructorId, int courseId, int groupId, int page, int pageSize)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var task = groupId == 0 ?
            _groupRepository.GetLearnersInCourseAsync(courseId, page, pageSize) :
            _groupRepository.GetLearnersInGroupAsync(groupId, page, pageSize);
        // Potential for leak as groupId-courseId connection is not checked

        task.Wait();
        return task.Result;
    }
}