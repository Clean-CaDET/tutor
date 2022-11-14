using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.Domain.Stakeholders;

public interface IEnrollmentRepository
{
    Instructor GetByUserId(int userId);
    List<Course> GetOwnedCourses(int instructorId);

    List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId);
}