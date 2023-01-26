using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Monitoring;

public interface IEnrollmentService
{
    Result<List<Course>> GetEnrolledCourses(int learnerId);
    Result<Course> GetCourseWithEnrolledAndActiveUnits(int courseId, int learnerId);

    Result<List<UnitEnrollment>> GetEnrollments(int unitId, int[] learnerIds, int instructorId);
    Result<List<UnitEnrollment>> BulkEnroll(int unitId, int[] learnerIds, int instructorId);
    Result<UnitEnrollment> Enroll(int unitId, int learnerId, int instructorId);
    Result Unenroll(int unitId, int learnerId, int instructorId);
}