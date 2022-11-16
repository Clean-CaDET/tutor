using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.Structure;

namespace Tutor.Core.UseCases.CourseIterationManagement;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }
    
    public Result<List<Course>> GetEnrolledCourses(int learnerId)
    {
        return _enrollmentRepository.GetEnrolledCourses(learnerId).ToResult();
    }

    public Result<List<KnowledgeUnit>> GetActiveUnits(int courseId, int learnerId)
    {
        return Result.Ok(_enrollmentRepository.GetEnrolledAndActiveUnits(courseId, learnerId));
    }
}