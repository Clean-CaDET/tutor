using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Public;
using Tutor.KnowledgeComponents.API.Public.Learning.Assessment;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

namespace Tutor.KnowledgeComponents.Core.UseCases.Learning.Assessment;

public class SelectionService : ISelectionService
{
    private readonly IMapper _mapper;
    private readonly IAccessService _accessService;
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAssessmentItemSelector _assessmentItemSelector;
    private readonly IAssessmentItemRepository _assessmentItemRepository;
    private readonly IKnowledgeComponentsUnitOfWork _unitOfWork;

    public SelectionService(IMapper mapper, IAccessService accessService,
        IKnowledgeMasteryRepository knowledgeMasteryRepository, IAssessmentItemSelector assessmentItemSelector,
        IAssessmentItemRepository assessmentItemRepository, IKnowledgeComponentsUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _accessService = accessService;
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _assessmentItemSelector = assessmentItemSelector;
        _assessmentItemRepository = assessmentItemRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<AssessmentItemDto> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId, string appClientId)
    {
        if (!_accessService.IsEnrolledInKc(knowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcMastery = _knowledgeMasteryRepository.GetFull(knowledgeComponentId, learnerId);
        if(kcMastery == null)
            return Result.Fail(FailureCode.NotFound);

        var assessmentItemId = _assessmentItemSelector.SelectSuitableAssessmentItemId(kcMastery.AssessmentItemMasteries.OrderBy(m => m.Id).ToList(), kcMastery.IsPassed);

        kcMastery.RecordAssessmentItemSelection(assessmentItemId, appClientId);
        _knowledgeMasteryRepository.Update(kcMastery);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        var item = _assessmentItemRepository.GetDerivedAssessmentItem(assessmentItemId);
        item?.ClearFeedback();

        return _mapper.Map<AssessmentItemDto>(item);
    }

    public Result<List<AssessmentItemDto>> GetAssessmentItems(int kcId, int learnerId, string appClientId)
    {
        if (!_accessService.IsEnrolledInKc(kcId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcMastery = _knowledgeMasteryRepository.GetFull(kcId, learnerId);
        if (kcMastery == null)
            return Result.Fail(FailureCode.NotFound);
        if(!kcMastery.IsSatisfied)
            return Result.Fail(FailureCode.Forbidden);

        kcMastery.RecordAssessmentItemsReviewed(appClientId);
        _knowledgeMasteryRepository.Update(kcMastery);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        var items = _assessmentItemRepository.GetDerivedAssessmentItemsForKc(kcId);
        return items.OrderBy(i => i.Order).Select(_mapper.Map<AssessmentItemDto>).ToList();
    }
}