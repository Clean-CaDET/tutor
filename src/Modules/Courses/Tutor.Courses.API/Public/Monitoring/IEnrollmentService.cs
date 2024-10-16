﻿using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Enrollments;

namespace Tutor.Courses.API.Public.Monitoring;

public interface IEnrollmentService
{
    Result<List<EnrollmentDto>> GetEnrollments(UnitAndLearnerIdsDto enrollmentFilter, int instructorId);
    Result<List<EnrollmentDto>> BulkEnroll(int unitId, int[] learnerIds, EnrollmentDto newEnrollment, int instructorId);
    Result<List<EnrollmentDto>> BulkUnenroll(int unitId, int[] learnerIds, int instructorId);
}