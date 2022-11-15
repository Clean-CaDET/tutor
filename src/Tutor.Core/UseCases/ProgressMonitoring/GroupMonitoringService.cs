using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Core.UseCases.ProgressMonitoring;

public class GroupMonitoringService : IGroupMonitoringService
{
    private readonly IGroupRepository _groupRepository;

    public GroupMonitoringService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId)
    {
        return _groupRepository.GetAssignedGroups(instructorId, courseId).ToResult();
    }
}