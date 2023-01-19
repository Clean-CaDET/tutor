using System.Collections.Generic;
using System.Linq;
using FluentResults;
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
        return _groupRepository.GetLearnersInGroup(groupId);
    }

    public Result CreateMembers(int groupId, List<Learner> learners)
    {
        var memberships = learners.Select(l => new GroupMembership(l, groupId));
        _groupRepository.CreateBulkMemberships(memberships);
        return Result.Ok();
    }

    public Result DeleteMember(int groupId, int learnerId)
    {
        _groupRepository.DeleteMember(groupId, learnerId);
        return Result.Ok();
    }
}