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
        var isOwner = _ownedCourseRepository.IsOwner(courseId, instructorId);
        if (!isOwner) return Result.Fail(FailureCode.Forbidden);
        return _groupRepository.GetCourseGroups(courseId);
    }

    public Result<PagedResult<Learner>> GetLearnersWithProgress(int courseId, int instructorId, int page, int pageSize)
    {
        return GetLearnersWithProgressForGroup(courseId, instructorId, 0, page, pageSize);
    }

    public Result<PagedResult<Learner>> GetLearnersWithProgressForGroup(int courseId, int instructorId, int groupId, int page, int pageSize)
    {
        var isOwner = _ownedCourseRepository.IsOwner(courseId, instructorId);
        if (!isOwner) return Result.Fail(FailureCode.Forbidden);

        var task = _groupRepository.GetGroupProgressAsync(courseId, groupId, page, pageSize);
        task.Wait();
        return task.Result;
    }
}