using System.Collections.Generic;
using FluentResults;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;

namespace Tutor.Core.InstructorModel;

public interface IInstructorService
{
    Result<List<Course>> GetOwnedCourses(int instructorId);

    Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId);
}