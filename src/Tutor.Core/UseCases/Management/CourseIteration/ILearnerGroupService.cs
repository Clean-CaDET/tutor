using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Core.UseCases.Management.CourseIteration;

public interface ILearnerGroupService
{
    Result<List<LearnerGroup>> GetByCourse(int courseId);
    Result<LearnerGroup> Create(LearnerGroup group);
    Result<LearnerGroup> Update(LearnerGroup group);
    Result Delete(int id);
}