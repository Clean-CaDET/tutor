using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.Management.CourseIteration;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }

    public Result<List<Course>> GetEnrolledCourses(int learnerId)
    {
        return _enrollmentRepository.GetEnrolledCourses(learnerId);
    }

    public Result<Course> GetCourseWithEnrolledAndActiveUnits(int courseId, int learnerId)
    {
        // Should change when course iteration is introduced
        return _enrollmentRepository.GetCourseEnrolledAndActiveUnits(courseId, learnerId);
    }
}