using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.ProgressMonitoring;

public class GroupMonitoringService : IGroupMonitoringService
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public GroupMonitoringService(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }

    public Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId)
    {
        return _enrollmentRepository.GetAssignedGroups(instructorId, courseId).ToResult();
    }
}