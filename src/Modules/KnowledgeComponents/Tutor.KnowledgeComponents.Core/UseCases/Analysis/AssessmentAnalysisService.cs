using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.Domain.EventSourcing;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Analysis;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

namespace Tutor.KnowledgeComponents.Core.UseCases.Analysis;

public class AssessmentAnalysisService<TEvent> : IAssessmentAnalysisService where TEvent : KnowledgeComponentEvent
{
    private readonly IMapper _mapper;
    private readonly IAccessService _accessService;
    private readonly IEventStore<TEvent> _eventStore;
    private readonly AssessmentStatisticsCalculator _calculator;

    public AssessmentAnalysisService(IMapper mapper, IAccessService accessService, IEventStore<TEvent> eventStore)
    {
        _mapper = mapper;
        _accessService = accessService;
        _eventStore = eventStore;
        _calculator = new AssessmentStatisticsCalculator();
    }

    public Result<List<AiStatisticsDto>> GetStatistics(int kcId, int instructorId)
    {
        if(!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var events = _eventStore.Events
            .Where(e => e.RootElement.GetProperty("KnowledgeComponentId").GetInt32() == kcId)
            .ToList<TEvent>();

        return CalculateStatistics(events);
    }

    private List<AiStatisticsDto> CalculateStatistics(List<TEvent> events)
    {
        var sortedAiEvents = events.OfType<AssessmentItemEvent>()
            .OrderBy(e => e.TimeStamp).ToList();
        var aiIds = sortedAiEvents.Select(e => e.AssessmentItemId).Distinct();

        return aiIds.Select(aiId => _mapper.Map<AiStatisticsDto>(_calculator.Calculate(aiId, sortedAiEvents))).ToList();
    }

    public Result<List<SubmissionCountDto>> Get5MostFrequentWrongSubmissions(int kcId, int aiId, int instructorId)
    {
        if (!_accessService.IsKcOwner(kcId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var aiAnswers = _eventStore.Events.Where(e =>
                e.RootElement.GetProperty("$discriminator").GetString() == "AssessmentItemAnswered" &&
                e.RootElement.GetProperty("AssessmentItemId").GetInt32() == aiId)
            .ToList<TEvent>() as List<AssessmentItemAnswered>;

        var incorrectSubmissions = aiAnswers
            .Where(answer => !answer.Feedback.Evaluation.Correct)
            .Select(answer => answer.Submission).ToList();

        var commonIncorrectSubmission = incorrectSubmissions
            .GroupBy(submission => submission)
            .Select(groupedSubmissions => new SubmissionCountDto
            {
                Count = groupedSubmissions.Count(),
                Submission = _mapper.Map<SubmissionDto>(groupedSubmissions.Key)
            })
            .OrderByDescending(x => x.Count)
            .Take(5)
            .ToList();

        return commonIncorrectSubmission;
    }
}