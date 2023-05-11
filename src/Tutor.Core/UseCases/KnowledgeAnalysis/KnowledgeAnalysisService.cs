using System;
using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeAnalysis;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.KnowledgeMastery.Events;
using Tutor.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.KnowledgeAnalysis;

public class KnowledgeAnalysisService : IKnowledgeAnalysisService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IEventStore _eventStore;
    private readonly IKnowledgeMasteryRepository _masteryRepository;

    public KnowledgeAnalysisService(IGroupRepository groupRepository, IOwnedCourseRepository ownedCourseRepository, IEventStore eventStore, IKnowledgeMasteryRepository masteryRepository)
    {
        _groupRepository = groupRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _eventStore = eventStore;
        _masteryRepository = masteryRepository;
    }

    public Result<KcStatistics> GetStatistics(int kcId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .ToList<KnowledgeComponentEvent>();

        return CalculateStatistics(kcId, events, _masteryRepository.Count(kcId)); // Add KcRegistration event?
    }

    public Result<KcStatistics> GetStatisticsForGroup(int kcId, int groupId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var learnerIds = _groupRepository.GetLearnerIdsInGroup(groupId);
        
        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .Where(e => learnerIds.Contains(e.RootElement.GetProperty("LearnerId").GetInt32()))
            .ToList<KnowledgeComponentEvent>();

        return CalculateStatistics(kcId, events, learnerIds.Count);
    }

    private static KcStatistics CalculateStatistics(int kcId, List<KnowledgeComponentEvent> events, int registeredCount)
    {
        return new KcStatistics
        {
            KcId = kcId,
            TotalRegistered = registeredCount,
            TotalStarted = events.OfType<KnowledgeComponentStarted>().Count(),
            TotalCompleted = events.OfType<KnowledgeComponentCompleted>().Count(),
            TotalPassed = events.OfType<KnowledgeComponentPassed>().Count(),
            MinutesToCompletion = GetMinutesToCompletion(events),
            MinutesToPass = GetMinutesToPass(events)
        };
    }

    private static List<double> GetMinutesToCompletion(List<KnowledgeComponentEvent> events)
    {
        return events.OfType<KnowledgeComponentCompleted>()
            .Select(e => Math.Round(e.MinutesToCompletion, 2)).ToList();
    }

    private static List<double> GetMinutesToPass(List<KnowledgeComponentEvent> events)
    {
        return events.OfType<KnowledgeComponentPassed>()
            .Select(e => Math.Round(e.MinutesToPass, 2)).ToList();
    }
}