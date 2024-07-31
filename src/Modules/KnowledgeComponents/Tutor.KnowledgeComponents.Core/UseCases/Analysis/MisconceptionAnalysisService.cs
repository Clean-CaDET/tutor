using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

namespace Tutor.KnowledgeComponents.Core.UseCases.Analysis;

public class MisconceptionAnalysisService<TEvent> : IMisconceptionAnalysisService where TEvent : KnowledgeComponentEvent
{
    private readonly IMapper _mapper;
    private readonly IAccessService _accessService;
    private readonly IEventStore<TEvent> _eventStore;
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly AssessmentStatisticsCalculator _calculator;

    public MisconceptionAnalysisService(IMapper mapper, IAccessService accessService, IEventStore<TEvent> eventStore, IKnowledgeComponentRepository kcRepository)
    {
        _mapper = mapper;
        _accessService = accessService;
        _eventStore = eventStore;
        _kcRepository = kcRepository;
        _calculator = new AssessmentStatisticsCalculator();
    }

    public Result<List<AiStatisticsDto>> GetTop10MisconceivedAssessments(int unitId, int instructorId)
    {
        if(!_accessService.IsUnitOwner(unitId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var kcIds = _kcRepository.GetByUnit(unitId).Select(kc => kc.Id).ToList();

        var events = _eventStore.Events
            .Where(e => kcIds.Contains(e.RootElement.GetProperty("KnowledgeComponentId").GetInt32()))
            .ToList<TEvent>();

        return CalculateStatistics(events)
            .Where(e => e.AttemptsToPass.Count > 0)
            .OrderByDescending(e => e.AttemptsToPass.Average())
            .Take(10)
            .ToList();
    }

    private List<AiStatisticsDto> CalculateStatistics(List<TEvent> events)
    {
        var sortedAiEvents = events.OfType<AssessmentItemEvent>()
            .OrderBy(e => e.TimeStamp).ToList();
        var aiIds = sortedAiEvents.Select(e => e.AssessmentItemId).Distinct();

        return aiIds.Select(aiId => _mapper.Map<AiStatisticsDto>(_calculator.Calculate(aiId, sortedAiEvents))).ToList();
    }
}