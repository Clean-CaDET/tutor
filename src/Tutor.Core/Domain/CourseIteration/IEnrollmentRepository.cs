using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.CourseIteration;

public interface IEnrollmentRepository
{
    PagedResult<Course> GetEnrolledCourses(int learnerId, int page, int pageSize);
    Course GetEnrolledCourse(int courseId, int learnerId);
    List<UnitEnrollment> GetEnrollmentsWithUnitsByCourse(int courseId, int learnerId);
    UnitEnrollment GetEnrollmentForKc(int knowledgeComponentId, int learnerId);
    UnitEnrollment GetEnrollment(int unitId, int learnerId);
    List<UnitEnrollment> GetEnrollments(int unitId, int[] learnerIds);
    UnitEnrollment Create(UnitEnrollment newEnrollment);
    UnitEnrollment Update(UnitEnrollment enrollment);
    List<UnitEnrollment> GetActiveEnrollmentsForCourse(int courseId);
}