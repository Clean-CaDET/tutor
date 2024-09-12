using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.Courses.Core.UseCases.Management;

public class GroupMembershipService: IGroupMembershipService
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly IInternalLearnerService _learnerService;

    public GroupMembershipService(IMapper mapper, IGroupRepository groupRepository,
        ICoursesUnitOfWork unitOfWork, IInternalLearnerService learnerService)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
        _unitOfWork = unitOfWork;
        _learnerService = learnerService;
    }

    public Result<List<LearnerDto>> GetMembers(int groupId)
    {
        var group = _groupRepository.Get(groupId);
        if(group == null) return Result.Fail(FailureCode.NotFound);

        var result = _learnerService.GetMany(group.LearnerIds.ToList());

        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.Select(_mapper.Map<LearnerDto>).ToList();
    }

    public Result CreateMembers(int groupId, List<int> learnerIds)
    {
        var group = _groupRepository.Get(groupId);
        if (group == null) return Result.Fail(FailureCode.NotFound);

        group.AddMembers(learnerIds);
        _groupRepository.Update(group);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;
        
        return Result.Ok();
    }

    public Result DeleteMember(int groupId, int learnerId)
    {
        var group = _groupRepository.Get(groupId);
        if (group is null) return Result.Fail(FailureCode.NotFound);

        group.RemoveMember(learnerId);
        _groupRepository.Update(group);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}