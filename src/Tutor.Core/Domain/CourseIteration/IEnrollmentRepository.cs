using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;

namespace Tutor.Core.Domain.CourseIteration
{
    public interface IEnrollmentRepository
    {
        int CountAllEnrollmentsInUnit(int unitId);
        List<Course> GetEnrolledCourses(int learnerId);
        List<KnowledgeUnit> GetEnrolledAndActiveUnits(int courseId, int learnerId);
        bool LearnerHasActiveEnrollment(int unitId, int learnerId);
    }
}
