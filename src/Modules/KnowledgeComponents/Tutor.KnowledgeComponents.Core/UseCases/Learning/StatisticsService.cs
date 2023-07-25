using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;
using Tutor.KnowledgeComponents.API.Interfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Learning;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.UseCases.Learning;

public class StatisticsService : IStatisticsService
{
    private readonly IMapper _mapper;
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAccessService _accessService;

    public StatisticsService(IMapper mapper, IKnowledgeMasteryRepository knowledgeMasteryRepository, IAccessService accessService)
    {
        _mapper = mapper;
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _accessService = accessService;
    }

    public Result<KcMasteryStatisticsDto> GetKcMasteryStatistics(int knowledgeComponentId, int learnerId)
    {
        if (!_accessService.IsEnrolledInKc(knowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcMastery = _knowledgeMasteryRepository.GetFull(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail(FailureCode.NotFound);

        return _mapper.Map<KcMasteryStatisticsDto>(kcMastery.Statistics);
    }

    public Result<double> GetMaxAssessmentCorrectness(int assessmentItemId, int learnerId)
    {
        var kcm = _knowledgeMasteryRepository.GetFullByAssessmentItem(assessmentItemId, learnerId);
        var itemMastery = kcm.AssessmentItemMasteries.Find(am => am.AssessmentItemId == assessmentItemId);
        return itemMastery?.Mastery ?? 0.0;
    }
}