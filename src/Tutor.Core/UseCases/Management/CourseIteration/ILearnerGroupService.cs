using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.CourseIteration;

public interface ILearnerGroupService
{
    Result<List<LearnerGroup>> GetByCourse(int courseId);
    Result<List<Learner>> GetMembers(int groupId);
    Result<LearnerGroup> Create(LearnerGroup group);
    Result<LearnerGroup> Update(LearnerGroup group);
    Result Delete(int id);
}