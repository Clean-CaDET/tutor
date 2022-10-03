using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.EnrollmentModel;

public interface IEnrollmentService
{
    Result<List<Course>> GetOwnedCourses(int instructorId);

    Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId);
}