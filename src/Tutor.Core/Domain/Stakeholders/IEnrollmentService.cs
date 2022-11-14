using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.Domain.Stakeholders;

public interface IEnrollmentService
{
    Result<List<Course>> GetOwnedCourses(int instructorId);

    Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId);
}