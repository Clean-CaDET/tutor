using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Groups;

public interface ILearnerGroupService
{
    Result<PagedResult<LearnerGroup>> GetByCourse(int courseId, int page, int pageSize);
    Result<LearnerGroup> Create(LearnerGroup group);
    Result<LearnerGroup> Update(LearnerGroup group);
    Result Delete(int id);
    Result<List<Learner>> GetMembers(int groupId);
    Result CreateMembers(int groupId, List<Learner> learners);
    Result DeleteMember(int groupId, int learnerId);
}