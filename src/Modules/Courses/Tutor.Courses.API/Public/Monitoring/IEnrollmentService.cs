using FluentResults;
using Tutor.Courses.API.Dtos;

namespace Tutor.Courses.API.Public.Monitoring;

public interface IEnrollmentService
{
    Result<List<UnitEnrollmentDto>> GetEnrollments(int unitId, int[] learnerIds, int instructorId);
    Result<List<UnitEnrollmentDto>> BulkEnroll(int unitId, int[] learnerIds, DateTime start, int instructorId);
    Result<UnitEnrollmentDto> Enroll(int unitId, int learnerId, DateTime start, int instructorId);
    Result Unenroll(int unitId, int learnerId, int instructorId);
    Result<List<UnitEnrollmentDto>> BulkUnenroll(int unitId, int[] learnerIds, int instructorId);
}