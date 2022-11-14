using FluentResults;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning.Assessment;

public class SelectionService : ISelectionService
{
    private readonly IKcMasteryRepository _kcMasteryRepository;
    private readonly IAssessmentItemSelector _assessmentItemSelector;

    public SelectionService(IKcMasteryRepository kcMasteryRepository, IAssessmentItemSelector assessmentItemSelector)
    {
        _kcMasteryRepository = kcMasteryRepository;
        _assessmentItemSelector = assessmentItemSelector;
    }

    public Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId)
    {
        var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
        if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);
        var selectionResult =
            _assessmentItemSelector.SelectSuitableAssessmentItemId(kcMastery.AssessmentItemMasteries, kcMastery.IsPassed);
        if (selectionResult.IsFailed) return selectionResult.ToResult<AssessmentItem>();

        var masteryResult = kcMastery.RecordAssessmentItemSelection(selectionResult.Value);
        if (masteryResult.IsFailed) return masteryResult.ToResult<AssessmentItem>();

        _kcMasteryRepository.UpdateKcMastery(kcMastery);

        return Result.Ok(_kcMasteryRepository.GetDerivedAssessmentItem(selectionResult.Value));
    }
}