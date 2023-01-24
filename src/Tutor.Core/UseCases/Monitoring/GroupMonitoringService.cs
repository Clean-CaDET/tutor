using FluentResults;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.Stakeholders;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.Monitoring;

public class GroupMonitoringService : IGroupMonitoringService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;

    public GroupMonitoringService(IGroupRepository groupRepository, 
        IOwnedCourseRepository ownedCourseRepository)
    {
        _groupRepository = groupRepository;
        _ownedCourseRepository = ownedCourseRepository;
    }

    public Result<List<LearnerGroup>> GetCourseGroups(int instructorId, int courseId)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId)) return Result.Fail(FailureCode.Forbidden);
        return _groupRepository.GetCourseGroups(courseId);
    }

    public Result<PagedResult<Learner>> GetLearners(int instructorId, int courseId, int groupId, int page, int pageSize)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var task = groupId == 0 ?
            _groupRepository.GetLearnersInCourseAsync(courseId, page, pageSize) :
            _groupRepository.GetLearnersInGroupAsync(groupId, page, pageSize);
        // Potential for leak as groupId-courseId connection is not checked

        task.Wait();
        return task.Result;
    }

    public Result<List<KnowledgeComponentMastery>> GetLearnerProgress(int courseId, int unitId, int[] learnerIds, int instructorId)
    {
        if (learnerIds == null || learnerIds.Length == 0) return Result.Fail(FailureCode.NotFound);
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        return _groupRepository.GetMasteriesForLearnersAndUnit(unitId, learnerIds);
        // Not sure if this should be part of groupRepo.
    }

    public Result<PagedResult<Learner>> GetLearnersWithProgress(int courseId, int instructorId, int page, int pageSize)
    {
        return GetLearnersWithProgressForGroup(courseId, instructorId, 0, page, pageSize);
    }

    public Result<PagedResult<Learner>> GetLearnersWithProgressForGroup(int courseId, int instructorId, int groupId, int page, int pageSize)
    {
        var isOwner = _ownedCourseRepository.IsCourseOwner(courseId, instructorId);
        if (!isOwner) return Result.Fail(FailureCode.Forbidden);

        var task = _groupRepository.GetLearnersWithMasteries(courseId, groupId, page, pageSize);
        task.Wait();
        return task.Result;
    }
}