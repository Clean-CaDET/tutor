using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.Domain.Stakeholders;

public interface IOwnedCourseRepository
{
    List<Course> GetOwnedCourses(int instructorId);
    Course GetOwnedCourseWithUnits(int courseId, int instructorId);
}