using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Public.Management;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Courses.Core.Domain.TokenWallet;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.Courses.Core.UseCases.Management;

public class GroupMembershipService: IGroupMembershipService
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;
    private readonly ICoursesUnitOfWork _unitOfWork;
    private readonly IInternalLearnerService _learnerService;
    private readonly IWalletRepository _walletRepository;

    public GroupMembershipService(IMapper mapper, IGroupRepository groupRepository,
        ICoursesUnitOfWork unitOfWork, IInternalLearnerService learnerService, IWalletRepository walletRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
        _unitOfWork = unitOfWork;
        _learnerService = learnerService;
        _walletRepository = walletRepository;
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

        ProvisionWalletsIfNeeded(group.CourseId, learnerIds);

        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }

    private void ProvisionWalletsIfNeeded(int courseId, List<int> learnerIds)
    {
        var existingWallets = _walletRepository.GetByCourseAndLearners(courseId, learnerIds);
        var learnersWithoutWallets = learnerIds.Except(existingWallets.Select(w => w.LearnerId)).ToList();

        foreach (var learnerId in learnersWithoutWallets)
        {
            var wallet = new Wallet(learnerId, courseId, 2000000);
            _walletRepository.Create(wallet);
        }
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