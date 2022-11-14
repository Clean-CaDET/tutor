using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.StakeholderManagement;

public class InstructorService : IInstructorService
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public InstructorService(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }

    public Result<List<Course>> GetOwnedCourses(int instructorId)
    {
        return _enrollmentRepository.GetOwnedCourses(instructorId).ToResult();
    }
}