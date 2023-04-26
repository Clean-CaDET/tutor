using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Groups;

public class LearnerGroupService: CrudService<LearnerGroup>, ILearnerGroupService
{
    private readonly IGroupRepository _groupRepository;

    public LearnerGroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork) : base(groupRepository, unitOfWork)
    {
        _groupRepository = groupRepository;
    }

    public Result<PagedResult<LearnerGroup>> GetByCourse(int courseId, int page, int pageSize)
    {
        return _groupRepository.GetCourseGroups(courseId, page, pageSize);
    }

    public Result<PagedResult<Learner>> GetMembers(int groupId, int page, int pageSize)
    {
        var task = _groupRepository.GetLearnersInGroupAsync(groupId, page, pageSize);
        task.Wait();
        return task.Result;
    }

    public Result CreateMembers(int groupId, List<Learner> learners)
    {
        var memberships = learners.Select(l => new GroupMembership(l, groupId));
        _groupRepository.CreateBulkMemberships(memberships);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;
        
        return Result.Ok();
    }

    public Result DeleteMember(int groupId, int learnerId)
    {
        var membership = _groupRepository.GetGroupMembership(groupId, learnerId);
        if (membership is null) return Result.Fail(FailureCode.NotFound);

        _groupRepository.DeleteMember(membership);

        var result = UnitOfWork.Save();
        if (result.IsFailed) return result;

        return Result.Ok();
    }
}