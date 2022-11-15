using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.Domain.Stakeholders;

public interface IAvailableCourseRepository
{
    List<Course> GetOwnedCourses(int instructorId);
    Course GetOwnedCourseWithUnits(int courseId, int instructorId);
    List<Course> GetEnrolledCourses(int learnerId);
}