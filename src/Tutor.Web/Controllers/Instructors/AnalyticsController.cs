using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Infrastructure.Database.EventStore;
using Tutor.Web.Mappings.Analytics;

namespace Tutor.Web.Controllers.Instructors;

[Authorize(Policy = "instructorPolicy")]
[Route("api/analytics/")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    private readonly ILearnerRepository _learnerRepository;
    private readonly IKnowledgeUnitRepository _knowledgeUnitRepository;
    private readonly IEventStore _eventStore;
    private readonly IMapper _mapper;

    public AnalyticsController(ILearnerRepository learnerRepository, IKnowledgeUnitRepository knowledgeUnitRepository, IEventStore eventStore, IMapper mapper)
    {
        _learnerRepository = learnerRepository;
        _knowledgeUnitRepository = knowledgeUnitRepository;
        _eventStore = eventStore;
        _mapper = mapper;
    }

    [HttpGet("learner-progress")]
    public ActionResult<PagedResult<LearnerProgressDto>> GetProgress([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] int groupId
    ,  [FromQuery] int courseId)
    {
        var task = _learnerRepository.GetLearnersWithMasteriesAsync(page, pageSize, groupId, courseId);
        task.Wait();
        var results = task.Result.Results.Select(progress => _mapper.Map<LearnerProgressDto>(progress)).ToList();
        return Ok(new PagedResult<LearnerProgressDto>(results, task.Result.TotalCount));
    }

    [HttpGet("kc-statistics")]
    public ActionResult<List<KcStatisticsDto>> GetKcStatistics([FromQuery] int unitId, [FromQuery] int groupId)
    {
        // Should refactor. Need to research appropriate patterns for this case. AnalyticsService seems to be a simple solution.
        var unit = _knowledgeUnitRepository.Get(unitId);
        List<int> learnerIds = null;
        if(groupId != 0) learnerIds = _learnerRepository.GetByGroupId(groupId).Select(l => l.Id).ToList();
        List<int> kcIds = unit.KnowledgeComponents.Select(kc => kc.Id).ToList();

        var eventQuery = _eventStore.Events.Where(e => kcIds.Contains(e.RootElement.GetProperty("KnowledgeComponentId").GetInt32()));
        if (learnerIds != null)
            eventQuery = eventQuery.Where(e => learnerIds.Contains(e.RootElement.GetProperty("LearnerId").GetInt32()));
        var events = eventQuery.ToList<KnowledgeComponentEvent>();

        var enrolledLearnersCount = _learnerRepository.CountEnrolledInUnit(unit.Id, learnerIds);

        return Ok(CalculateKcStatistics(unit, events, enrolledLearnersCount));
    }

    private static List<KcStatisticsDto> CalculateKcStatistics(KnowledgeUnit unit, List<KnowledgeComponentEvent> events, int enrolledLearnersCount)
    {
        return unit.KnowledgeComponents.Select(kc =>
        {
            var kcEvents = events.Where(e => e.KnowledgeComponentId == kc.Id).ToList();
            var startedEvents = kcEvents.Where(e => e is KnowledgeComponentStarted).ToList();
            var completedEvents = kcEvents.Where(e => e is KnowledgeComponentCompleted).ToList();
            var passedEvents = kcEvents.Where(e => e is KnowledgeComponentPassed).ToList();

            return new KcStatisticsDto
            {
                KcCode = kc.Code,
                KcName = kc.Name,
                TotalRegistered = enrolledLearnersCount,
                TotalStarted = startedEvents.Count,
                TotalCompleted = completedEvents.Count,
                TotalPassed = passedEvents.Count,
                MinutesToCompletion = CalculateMinutesBetweenEvents(startedEvents, completedEvents),
                MinutesToPass = CalculateMinutesBetweenEvents(startedEvents, passedEvents)
            };
        }).ToList();
    }

    private static List<int> CalculateMinutesBetweenEvents(List<KnowledgeComponentEvent> startEvents, List<KnowledgeComponentEvent> endEvents)
    {
        var result = new List<int>();
        foreach (var endEvent in endEvents)
        {
            var matchingStartEvent = startEvents.Find(e => e.LearnerId == endEvent.LearnerId);
            if (matchingStartEvent == null) throw new InvalidOperationException();
            
            var minuteDifference = (endEvent.TimeStamp - matchingStartEvent.TimeStamp).TotalMinutes;
            result.Add((int)minuteDifference);
        }
        return result;
    }

    [HttpGet("events")]
    public ActionResult<PagedResult<DomainEvent>> GetEvents([FromQuery] int page, [FromQuery] int pageSize)
    {
        var task = _eventStore.GetEventsAsync(page, pageSize);
        task.Wait();
        return Ok(task.Result);
    }
    
    [HttpGet("all-events")]
    public ActionResult<List<DomainEvent>> GetAllEvents()
    {
        var result = _eventStore.Events.ToList();
        return Ok(result);
    }
}