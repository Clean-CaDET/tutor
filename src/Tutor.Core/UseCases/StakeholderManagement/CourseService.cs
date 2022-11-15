using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.StakeholderManagement;

public class CourseService : ICourseService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly ICourseRepository _courseRepository;

    public CourseService(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository)
    {
        _enrollmentRepository = enrollmentRepository;
        _courseRepository = courseRepository;
    }

    public Result<List<Course>> GetOwnedCourses(int instructorId)
    {
        return _enrollmentRepository.GetOwnedCourses(instructorId).ToResult();
    }

    public Result<List<Course>> GetEnrolledCourses(int learnerId)
    {
        return _courseRepository.GetCoursesByLearner(learnerId).ToResult();
    }
}