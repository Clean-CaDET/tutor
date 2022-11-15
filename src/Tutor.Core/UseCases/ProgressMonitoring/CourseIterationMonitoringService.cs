using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.ProgressMonitoring;

public class CourseIterationMonitoringService : ICourseIterationMonitoringService
{
    private readonly IGroupRepository _groupRepository;

    public CourseIterationMonitoringService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Result<List<LearnerGroup>> GetAssignedGroups(int instructorId, int courseId)
    {
        return _groupRepository.GetAssignedGroups(instructorId, courseId).ToResult();
    }

    public PagedResult<Learner> GetLearnersWithProgress(int courseId, int page, int pageSize)
    {
        return GetLearnersWithProgressForGroup(courseId, 0, page, pageSize);
    }

    public PagedResult<Learner> GetLearnersWithProgressForGroup(int courseId, int groupId, int page, int pageSize)
    {
        var task = _groupRepository.GetLearnersWithProgressAsync(courseId, groupId, page, pageSize);
        task.Wait();
        return task.Result;
    }
}