using FluentResults;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning.Assessment;

public class SelectionService : ISelectionService
{
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAssessmentItemSelector _assessmentItemSelector;
    private readonly IAssessmentItemRepository _assessmentItemRepository;

    public SelectionService(IKnowledgeMasteryRepository knowledgeMasteryRepository, IAssessmentItemSelector assessmentItemSelector, IAssessmentItemRepository assessmentItemRepository)
    {
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _assessmentItemSelector = assessmentItemSelector;
        _assessmentItemRepository = assessmentItemRepository;
    }

    public Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId)
    {
        var kcMastery = _knowledgeMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);
        var selectionResult =
            _assessmentItemSelector.SelectSuitableAssessmentItemId(kcMastery.AssessmentItemMasteries, kcMastery.IsPassed);
        if (selectionResult.IsFailed) return selectionResult.ToResult<AssessmentItem>();

        var masteryResult = kcMastery.RecordAssessmentItemSelection(selectionResult.Value);
        if (masteryResult.IsFailed) return masteryResult.ToResult<AssessmentItem>();

        _knowledgeMasteryRepository.UpdateKcMastery(kcMastery);

        return Result.Ok(_assessmentItemRepository.GetDerivedAssessmentItem(selectionResult.Value));
    }
}