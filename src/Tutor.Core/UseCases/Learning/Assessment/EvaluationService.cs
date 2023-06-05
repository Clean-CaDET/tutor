using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.KnowledgeMastery.DomainServices;

namespace Tutor.Core.UseCases.Learning.Assessment;

public class EvaluationService : IEvaluationService
{
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAssessmentItemRepository _assessmentItemRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IAssessmentFeedbackGenerator _assessmentFeedbackGenerator;
    private readonly IUnitOfWork _unitOfWork;

    public EvaluationService(IKnowledgeMasteryRepository knowledgeMasteryRepository, IAssessmentItemRepository assessmentItemRepository, IEnrollmentRepository enrollmentRepository, IUnitOfWork unitOfWork, IAssessmentFeedbackGenerator assessmentFeedbackGenerator)
    {
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _assessmentItemRepository = assessmentItemRepository;
        _enrollmentRepository = enrollmentRepository;
        _assessmentFeedbackGenerator = assessmentFeedbackGenerator;
        _unitOfWork = unitOfWork;
    }

    public Result<Feedback> EvaluateAssessmentItemSubmission(int assessmentItemId, Submission submission, int learnerId)
    {
        var assessmentItem = _assessmentItemRepository.GetDerivedAssessmentItem(assessmentItemId);
        if (assessmentItem == null) return Result.Fail(FailureCode.NotFound);
        if (!_enrollmentRepository.GetEnrollmentForKc(assessmentItem.KnowledgeComponentId, learnerId).IsActive())
            return Result.Fail(FailureCode.NotEnrolledInUnit);
        var kcMastery = _knowledgeMasteryRepository.GetFull(assessmentItem.KnowledgeComponentId, learnerId);
        
        var feedback = _assessmentFeedbackGenerator.CreateFeedback(
            kcMastery.AssessmentItemMasteries.Find(m => m.AssessmentItemId == assessmentItemId),
            assessmentItem, submission);
        if (feedback.IsFailed) return feedback;

        var result = RecordSubmission(kcMastery, assessmentItemId, submission, feedback.Value);
        if (result.IsFailed) return result;

        return feedback;
    }

    private Result RecordSubmission(KnowledgeComponentMastery kcMastery, int itemId, Submission submission, Feedback feedback)
    {
        if (feedback.FeedbackType == FeedbackType.Hint) kcMastery.RecordAssessmentItemHintRequest(itemId, feedback.Hint.Markdown);
        kcMastery.RecordAssessmentItemAnswerSubmission(itemId, submission, feedback);
        _knowledgeMasteryRepository.Update(kcMastery);
        return _unitOfWork.Save();
    }
}