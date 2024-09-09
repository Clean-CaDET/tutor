using FluentResults;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.KnowledgeComponentEvents;

namespace Tutor.KnowledgeComponents.Core.UseCases.Monitoring;

public class MasteryMonitoringService : IKcProgressService, IMasteryFactory
{
    private readonly IKnowledgeComponentRepository _kcRepository;
    private readonly IKnowledgeMasteryRepository _masteryRepository;
    private readonly IKnowledgeComponentsUnitOfWork _unitOfWork;
    private readonly IEventStore<KnowledgeComponentEvent> _eventStore;
    private readonly List<INegativePatternDetector> _negativePatternDetectors;


    public MasteryMonitoringService(IKnowledgeComponentRepository kcRepository, IKnowledgeMasteryRepository masteryRepository,
        IKnowledgeComponentsUnitOfWork unitOfWork, IEventStore<KnowledgeComponentEvent> eventStore)
    {
        _kcRepository = kcRepository;
        _masteryRepository = masteryRepository;
        _unitOfWork = unitOfWork;
        _eventStore = eventStore;
        _negativePatternDetectors = new List<INegativePatternDetector>
        {
            new PatternDetectorSatisfaction(),
            new PatternDetectorInstruction(),
            new PatternDetectorAssessment()
        };
    }

    public Result InitializeMasteries(int unitId, int[] learnerIds)
    {
        Array.ForEach(learnerIds, learnerId => CreateMasteries(unitId, learnerId));
        return _unitOfWork.Save();
    }

    private void CreateMasteries(int unitId, int learnerId)
    {
        var kcs = _kcRepository.GetByUnitWithAssessments(unitId);
        foreach (var kc in kcs)
        {
            var assessmentMasteries = kc.AssessmentItems?
                .OrderBy(i => i.Order)
                .Select(item => new AssessmentItemMastery(item.Id)).ToList();
            var kcMastery = new KnowledgeComponentMastery(learnerId, kc.Id, assessmentMasteries);
            _masteryRepository.Create(kcMastery);
        }
    }

    public Result<List<InternalKcUnitSummaryStatisticsDto>> GetProgress(int learnerId, int[] unitIds)
    {
        if (unitIds.Length == 0) return Result.Fail(FailureCode.NotFound);

        var kcs = _kcRepository.GetByUnits(unitIds);
        var kcIds = kcs.Select(kc => kc.Id).ToHashSet();

        var orderedEvents = _eventStore.GetEventsByUserAndPrimaryEntities(learnerId, kcIds);

        return CalculateProgressStatistics(kcs, orderedEvents);
    }

    private List<InternalKcUnitSummaryStatisticsDto> CalculateProgressStatistics(List<KnowledgeComponent> kcs, List<KnowledgeComponentEvent> events)
    {
        var groupedKcs = kcs.GroupBy(kc => kc.KnowledgeUnitId);
        return groupedKcs.Select(grouping => CalculateKcProgressForUnit(events, grouping)).ToList();
    }

    private InternalKcUnitSummaryStatisticsDto CalculateKcProgressForUnit(List<KnowledgeComponentEvent> events, IGrouping<int, KnowledgeComponent> grouping)
    {
        var kcProgressStatistics = new List<InternalKcProgressStatisticsDto>();
        
        foreach (var kc in grouping)
        {
            var orderedKcEvents = events
                .Where(e => e.KnowledgeComponentId == kc.Id)
                .OrderBy(e => e.TimeStamp)
                .ToList();

            var satisfiedIndex = orderedKcEvents.FindIndex(e => e is KnowledgeComponentSatisfied);
            if (satisfiedIndex == -1) continue;

            var eventsUpToSatisfied = orderedKcEvents.Take(satisfiedIndex + 1).ToList();

            kcProgressStatistics.Add(CreateKcStatistics(eventsUpToSatisfied, kc));
        }

        return new InternalKcUnitSummaryStatisticsDto
        {
            UnitId = grouping.Key,
            TotalCount = grouping.Count(),
            SatisfiedCount = kcProgressStatistics.Count,
            KcProgressStatisticsDto = kcProgressStatistics
        };
    }

    private InternalKcProgressStatisticsDto CreateKcStatistics(List<KnowledgeComponentEvent> eventsUpToSatisfied, KnowledgeComponent kc)
    {
        var negativePatterns = new List<string>();
        foreach (var detector in _negativePatternDetectors)
        {
            negativePatterns.AddRange(detector.Detect(eventsUpToSatisfied, kc));
        }

        return new InternalKcProgressStatisticsDto
        {
            KcId = kc.Id,
            SatisfactionTime = eventsUpToSatisfied[^1].TimeStamp,
            NegativePatterns = negativePatterns
        };
    }
}