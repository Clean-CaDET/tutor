using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.Enrollments;

public interface IEnrollmentService
{
    Result<List<Course>> GetEnrolledCourses(int learnerId);
    Result<Course> GetCourseWithEnrolledAndActiveUnits(int courseId, int learnerId);
}