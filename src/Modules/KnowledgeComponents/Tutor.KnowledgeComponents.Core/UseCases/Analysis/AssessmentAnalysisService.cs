using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

namespace Tutor.KnowledgeComponents.Core.UseCases.Analysis;

public class AssessmentAnalysisService : IAssessmentAnalysisService
{
    private readonly IMapper _mapper;
    private readonly IAccessService _accessService;
    private readonly IEventStore _eventStore;

    public AssessmentAnalysisService(IMapper mapper, IAccessService accessService, IEventStore eventStore)
    {
        _mapper = mapper;
        _accessService = accessService;
        _eventStore = eventStore;
    }

    public Result<List<AiStatisticsDto>> GetStatistics(int kcId, int instructorId)
    {
        if(!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .ToList<KnowledgeComponentEvent>();

        return CalculateStatistics(events);
    }

    private List<AiStatisticsDto> CalculateStatistics(List<KnowledgeComponentEvent> events)
    {
        var sortedAiEvents = events.OfType<AssessmentItemEvent>()
            .OrderBy(e => e.TimeStamp).ToList();
        var aiIds = sortedAiEvents.Select(e => e.AssessmentItemId).Distinct();

        return aiIds.Select(aiId => _mapper.Map<AiStatisticsDto>(CreateAiStatistic(aiId, sortedAiEvents))).ToList();
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