using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Enrollments;

public class LearnerGroupService: CrudService<LearnerGroup>, ILearnerGroupService
{
    private readonly IGroupRepository _groupRepository;

    public LearnerGroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork) : base(groupRepository, unitOfWork)
    {
        _groupRepository = groupRepository;
    }

    public Result<List<LearnerGroup>> GetByCourse(int courseId)
    {
        return _groupRepository.GetCourseGroups(courseId);
    }

    public Result<List<Learner>> GetMembers(int groupId)
    {
        var task = _groupRepository.GetLearnersInGroupAsync(groupId, 0, 0);
        task.Wait();
        return task.Result.Results;
    }

    public Result CreateMembers(int groupId, List<Learner> learners)
    {
        var memberships = learners.Select(l => new GroupMembership(l, groupId));
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