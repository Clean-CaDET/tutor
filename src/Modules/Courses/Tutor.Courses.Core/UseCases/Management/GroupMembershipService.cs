using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Interfaces.Management;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Interfaces.Management;

namespace Tutor.Courses.Core.UseCases.Management;

public class GroupMembershipService: IGroupMembershipService
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILearnerService _learnerService;

    public GroupMembershipService(IMapper mapper, IGroupRepository groupRepository, IUnitOfWork unitOfWork, ILearnerService learnerService)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
        _unitOfWork = unitOfWork;
        _learnerService = learnerService;
    }

    public Result<List<LearnerDto>> GetGroupMembers(int groupId)
    {
        var learnerIds = _groupRepository.GetLearnerIdsInGroup(groupId);
        var result = _learnerService.GetMany(learnerIds);

        if (result.IsFailed) return Result.Fail(result.Errors);
        return result.Value.Select(_mapper.Map<LearnerDto>).ToList();
    }

    public Result CreateMembers(int groupId, List<int> learnerIds)
    {
        var memberships = learnerIds.Select(l => new GroupMembership(l, groupId));
        _groupRepository.CreateBulkMemberships(memberships);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;
        
        return Result.Ok();
    }

    public Result DeleteMember(int groupId, int learnerId)
    {
        var membership = _groupRepository.GetGroupMembership(groupId, learnerId);
        if (membership is null) return Result.Fail(FailureCode.NotFound);

        _groupRepository.DeleteMember(membership);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}