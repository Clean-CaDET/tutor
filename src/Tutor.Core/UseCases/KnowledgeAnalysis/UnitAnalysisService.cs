using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeAnalysis;
using Tutor.Core.Domain.KnowledgeMastery.Events;
using Tutor.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.KnowledgeAnalysis;

public class UnitAnalysisService : IUnitAnalysisService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IEventStore _eventStore;

    public UnitAnalysisService(IGroupRepository groupRepository, IOwnedCourseRepository ownedCourseRepository, IEventStore eventStore)
    {
        _groupRepository = groupRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _eventStore = eventStore;
    }

    public Result<KcStatistics> GetKcStatistics(int kcId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .ToList<KnowledgeComponentEvent>();

        return CalculateStatistics(kcId, events, 0); // Add KcRegistration event or count related KCMs?
    }

    public Result<KcStatistics> GetKcStatisticsForGroup(int kcId, int groupId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var task = _groupRepository.GetLearnersInGroupAsync(groupId, 0, 0);
        task.Wait();
        var learnerIds = task.Result.Results.Select(l => l.Id).ToList();
        
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
            .Select(e => e.MinutesToCompletion).ToList();
    }

    private static List<double> GetMinutesToPass(List<KnowledgeComponentEvent> events)
    {
        return events.OfType<KnowledgeComponentPassed>()
            .Select(e => e.MinutesToPass).ToList();
    }
}