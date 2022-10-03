using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.EnrollmentModel;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }
    
    public Result<List<Course>> GetOwnedCourses(int instructorId)
    {
        return _enrollmentRepository.GetOwnedCourses(instructorId).ToResult();
    }

    public Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId)
    {
        return _enrollmentRepository.GetAssignedGroups(instructorId, courseId).ToResult();
    }
}