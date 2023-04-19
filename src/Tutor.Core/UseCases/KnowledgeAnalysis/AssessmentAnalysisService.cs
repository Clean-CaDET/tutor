using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeAnalysis;
using Tutor.Core.Domain.KnowledgeMastery.Events;
using Tutor.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;
using Tutor.Core.Domain.Stakeholders.RepositoryInterfaces;

namespace Tutor.Core.UseCases.KnowledgeAnalysis;

public class AssessmentAnalysisService : IAssessmentAnalysisService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IEventStore _eventStore;

    public AssessmentAnalysisService(IGroupRepository groupRepository, IOwnedCourseRepository ownedCourseRepository, IEventStore eventStore)
    {
        _groupRepository = groupRepository;
        _ownedCourseRepository = ownedCourseRepository;
        _eventStore = eventStore;
    }

    public Result<List<AiStatistics>> GetAiStatistics(int kcId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .ToList<KnowledgeComponentEvent>();

        return CalculateStatistics(events);
    }

    public Result<List<AiStatistics>> GetAiStatisticsForGroup(int kcId, int groupId, int instructorId)
    {
        if (!_ownedCourseRepository.IsKcOwner(kcId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var learnerIds = _groupRepository.GetLearnerIdsInGroup(groupId);
        
        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .Where(e => learnerIds.Contains(e.RootElement.GetProperty("LearnerId").GetInt32()))
            .ToList<KnowledgeComponentEvent>();

        return CalculateStatistics(events);
    }

    private static List<AiStatistics> CalculateStatistics(List<KnowledgeComponentEvent> events)
    {
        var sortedAiEvents = events.OfType<AssessmentItemEvent>()
            .OrderBy(e => e.TimeStamp).ToList();
        var aiIds = sortedAiEvents.Select(e => e.AssessmentItemId).Distinct();

        return aiIds.Select(aiId => CreateAiStatistic(aiId, sortedAiEvents)).ToList();
    }

    private static AiStatistics CreateAiStatistic(int aiId, List<AssessmentItemEvent> events)
    {
        var eventsGroupedByLearner = events
            .Where(e => e.AssessmentItemId == aiId)
            .GroupBy(e => e.LearnerId)
            .ToList();

        var minutesToCompletion = eventsGroupedByLearner
            .Select(CalculateCompletionTime).Where(completionTime => completionTime != 0).ToList();
        
        var attemptsToPass = eventsGroupedByLearner
            .Select(CalculateAttemptsToPass).Where(completionTime => completionTime != 0).ToList();

        return new AiStatistics
        {
            AiId = aiId,
            KcId = events.First().KnowledgeComponentId,
            MinutesToCompletion = minutesToCompletion,
            AttemptsToPass = attemptsToPass
        };
    }

    private static double CalculateCompletionTime(IEnumerable<AssessmentItemEvent> events)
    {
        var aiEvents = events.ToList();
        var firstAiCompletion = aiEvents.OfType<AssessmentItemAnswered>().FirstOrDefault();

        if (firstAiCompletion == null) return 0;

        return CalculateMinuteDifference(firstAiCompletion, aiEvents.First());
    }

    private static int CalculateAttemptsToPass(IEnumerable<AssessmentItemEvent> events)
    {
        var aiEvents = events.ToList();
        var firstAiPass = aiEvents.OfType<AssessmentItemAnswered>().FirstOrDefault(e => e.Feedback.Evaluation.Correct);

        if (firstAiPass == null) return 0;

        return aiEvents.OfType<AssessmentItemAnswered>().Count(e => e.TimeStamp <= firstAiPass.TimeStamp);
    }

    private static double CalculateMinuteDifference(DomainEvent secondEvent, DomainEvent firstEvent)
    {
        return Math.Round((secondEvent.TimeStamp - firstEvent.TimeStamp).TotalMinutes, 2);
    }
}