using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.StakeholderManagement;

public class AvailableCourseService : IAvailableCourseService
{
    private readonly IAvailableCourseRepository _availableCourseRepository;

    public AvailableCourseService(IAvailableCourseRepository availableCourseRepository)
    {
        _availableCourseRepository = availableCourseRepository;
    }

    public Result<List<Course>> GetOwnedCourses(int instructorId)
    {
        return _availableCourseRepository.GetOwnedCourses(instructorId).ToResult();
    }

    public Result<List<Course>> GetEnrolledCourses(int learnerId)
    {
        return _availableCourseRepository.GetEnrolledCourses(learnerId).ToResult();
    }
}