using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Interfaces.Management;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Interfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Analysis;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

namespace Tutor.KnowledgeComponents.Core.UseCases.Analysis;

public class KnowledgeAnalysisService : IKnowledgeAnalysisService
{
    private readonly IMapper _mapper;
    private readonly IGroupMembershipService _groupService;
    private readonly IAccessService _accessService;
    private readonly IEventStore _eventStore;

    public KnowledgeAnalysisService(IMapper mapper, IGroupMembershipService groupService, IAccessService accessService, IEventStore eventStore)
    {
        _mapper = mapper;
        _groupService = groupService;
        _accessService = accessService;
        _eventStore = eventStore;
    }

    public Result<KcStatisticsDto> GetStatistics(int kcId, int instructorId)
    {
        if (!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .ToList<KnowledgeComponentEvent>();

        return CalculateStatistics(kcId, events, events.Select(e => e.LearnerId).Distinct().Count()); //TODO: Add KcRegistration event to catch completely inactive users
    }

    public Result<KcStatisticsDto> GetStatisticsForGroup(int kcId, int groupId, int instructorId)
    {
        if (!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var learnerIds = _groupService.GetMemberIds(groupId).Value;
        
        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .Where(e => learnerIds.Contains(e.RootElement.GetProperty("LearnerId").GetInt32()))
            .ToList<KnowledgeComponentEvent>();

        return CalculateStatistics(kcId, events, learnerIds.Count);
    }

    private KcStatisticsDto CalculateStatistics(int kcId, List<KnowledgeComponentEvent> events, int registeredCount)
    {
        var statistics = new KcStatistics
        {
            KcId = kcId,
            TotalRegistered = registeredCount,
            TotalStarted = events.OfType<KnowledgeComponentStarted>().Count(),
            TotalCompleted = events.OfType<KnowledgeComponentCompleted>().Count(),
            TotalPassed = events.OfType<KnowledgeComponentPassed>().Count(),
            MinutesToCompletion = GetMinutesToCompletion(events),
            MinutesToPass = GetMinutesToPass(events)
        };
        return _mapper.Map<KcStatisticsDto>(statistics);
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