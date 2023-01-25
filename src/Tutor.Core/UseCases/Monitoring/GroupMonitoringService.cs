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

    public Result<List<KnowledgeComponentMastery>> GetLearnerProgress(int unitId, int[] learnerIds, int instructorId)
    {
        if (learnerIds == null || learnerIds.Length == 0) return Result.Fail(FailureCode.NotFound);
        if (!_ownedCourseRepository.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        return _groupRepository.GetMasteriesForLearnersAndUnit(unitId, learnerIds);
        // Not sure if this should be part of groupRepo.
    }
}