using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.ProgressMonitoring;

public class CourseIterationMonitoringService : ICourseIterationMonitoringService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public CourseIterationMonitoringService(IGroupRepository groupRepository, 
        IOwnedCourseRepository ownedCourseRepository)
    {
        _groupRepository = groupRepository;
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<List<LearnerGroup>> GetCourseGroups(int instructorId, int courseId)
    {
        var ownership = _ownedCourseRepository.CheckOwnership(courseId, instructorId);
        if (ownership is null) return Result.Fail(FailureCode.Forbidden);
        return _groupRepository.GetCourseGroups(courseId);
    }

    public PagedResult<Learner> GetLearnersWithProgress(int courseId, int page, int pageSize)
    {
        return GetLearnersWithProgressForGroup(courseId, 0, page, pageSize);
    }

    public PagedResult<Learner> GetLearnersWithProgressForGroup(int courseId, int groupId, int page, int pageSize)
    {
        var task = _groupRepository.GetGroupProgressAsync(courseId, groupId, page, pageSize);
        task.Wait();
        return task.Result;
    }
}