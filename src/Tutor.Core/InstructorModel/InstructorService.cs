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
    
    public Result<List<Course>> GetCourses(int userId)
    {
        var instructor = _instructorRepository.GetByUserId(userId);
        return _instructorRepository.GetCourses(instructor.Id).ToResult();
    }

    public Result<List<LearnerGroup>> GetGroups(int userId, int courseId)
    {
        var instructor = _instructorRepository.GetByUserId(userId);
        return _instructorRepository.GetGroups(instructor.Id, courseId).ToResult();
    }
}