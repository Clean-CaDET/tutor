using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;

namespace Tutor.Core.InstructorModel;

public interface IInstructorRepository
{
    Instructor GetByUserId(int userId);
    List<Course> GetOwnedCourses(int instructorId);

    List<LearnerGroup> GetAssignedGroups(int instructorId, int courseId);
}