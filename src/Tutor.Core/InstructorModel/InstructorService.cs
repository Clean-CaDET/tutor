using System.Collections.Generic;
using FluentResults;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;

namespace Tutor.Core.InstructorModel;

public class InstructorService : IInstructorService
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorService(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }
    
    public Result<List<Course>> GetOwnedCourses(int instructorId)
    {
        return _instructorRepository.GetOwnedCourses(instructorId).ToResult();
    }

    public Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId)
    {
        return _instructorRepository.GetAssignedGroups(instructorId, courseId).ToResult();
    }
}