using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.Domain.CourseIteration;

public interface IEnrollmentRepository
{
    int CountEnrollmentsForUnit(int unitId);
    PagedResult<Course> GetEnrolledCourses(int learnerId, int page, int pageSize);
    Course GetCourseEnrolledAndActiveUnits(int courseId, int learnerId);
    bool HasActiveEnrollmentForUnit(int unitId, int learnerId);
    bool HasActiveEnrollmentForKc(int knowledgeComponentId, int learnerId);
    UnitEnrollment GetEnrollment(int unitId, int learnerId);
    List<UnitEnrollment> GetEnrollments(int unitId, int[] learnerIds);
    UnitEnrollment Create(UnitEnrollment newEnrollment);
    UnitEnrollment Update(UnitEnrollment enrollment);
}