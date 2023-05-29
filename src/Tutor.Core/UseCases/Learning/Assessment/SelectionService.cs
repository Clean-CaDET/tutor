using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.KnowledgeMastery.DomainServices;

namespace Tutor.Core.UseCases.Learning.Assessment;

public class SelectionService : ISelectionService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAssessmentItemSelector _assessmentItemSelector;
    private readonly IAssessmentItemRepository _assessmentItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SelectionService(IEnrollmentRepository enrollmentRepository, IKnowledgeMasteryRepository knowledgeMasteryRepository, IAssessmentItemSelector assessmentItemSelector, IAssessmentItemRepository assessmentItemRepository, IUnitOfWork unitOfWork)
    {
        _enrollmentRepository = enrollmentRepository;
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _assessmentItemSelector = assessmentItemSelector;
        _assessmentItemRepository = assessmentItemRepository;
        _unitOfWork = unitOfWork;
    }

    public Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId)
    {
        if (!_enrollmentRepository.GetEnrollmentForKc(knowledgeComponentId, learnerId).IsActive())
            return Result.Fail(FailureCode.NotEnrolledInUnit);

        var kcMastery = _knowledgeMasteryRepository.GetFull(knowledgeComponentId, learnerId);
        if(kcMastery == null) return Result.Fail(FailureCode.NotFound);

        var assessmentItemId = _assessmentItemSelector.SelectSuitableAssessmentItemId(kcMastery.AssessmentItemMasteries, kcMastery.IsPassed);

        kcMastery.RecordAssessmentItemSelection(assessmentItemId);
        _knowledgeMasteryRepository.Update(kcMastery);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;

        var item = _assessmentItemRepository.GetDerivedAssessmentItem(assessmentItemId);
        item.ClearFeedback();

        return Result.Ok(item);
    }
}