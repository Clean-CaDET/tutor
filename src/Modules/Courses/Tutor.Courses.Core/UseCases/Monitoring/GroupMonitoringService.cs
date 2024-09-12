using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class GroupMonitoringService : IGroupMonitoringService
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IInternalLearnerService _learnerService;

    public GroupMonitoringService(IMapper mapper, IGroupRepository groupRepository, 
        IOwnedCourseRepository ownedCourseRepository, IInternalLearnerService learnerService)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _learnerService = learnerService;
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

        return groupId != 0 ? GetGroupLearners(groupId) : GetCourseLearners(courseId, page, pageSize);
    }

    private Result<PagedResult<LearnerDto>> GetGroupLearners(int groupId)
    {
        var group = _groupRepository.Get(groupId);
        if(group == null) return Result.Fail(FailureCode.NotFound);

        return CreateResult(group.LearnerIds.ToList());
    }

    private Result<PagedResult<LearnerDto>> GetCourseLearners(int courseId, int page, int pageSize)
    {
        var groups = _groupRepository.GetCourseGroups(courseId);
        var allLearnerIds = groups
            .SelectMany(g => g.LearnerIds)
            .Distinct()
            .ToList();

        if (allLearnerIds.Count <= pageSize) return CreateResult(allLearnerIds);

        var learnerIds = allLearnerIds
            .OrderByDescending(l => l)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return CreateResult(learnerIds, allLearnerIds.Count);
    }

    private Result<PagedResult<LearnerDto>> CreateResult(List<int> learnerIds, int totalCount = 0)
    {
        var learners = _learnerService.GetMany(learnerIds);
        var learnerDtos = learners.Value
            .Select(_mapper.Map<LearnerDto>)
            .OrderByDescending(l => l.Id)
            .ToList();
        return new PagedResult<LearnerDto>(learnerDtos, totalCount == 0 ? learnerDtos.Count : totalCount);
    }
}