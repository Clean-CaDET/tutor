using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.EnrollmentModel;

public interface IEnrollmentRepository
{
    Instructor GetByUserId(int userId);
    List<Course> GetOwnedCourses(int instructorId);

    List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId);
}