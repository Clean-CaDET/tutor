using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.API.Interfaces;
using Tutor.KnowledgeComponents.API.Interfaces.Learning.Assessment;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

namespace Tutor.KnowledgeComponents.Core.UseCases.Learning.Assessment;

public class EvaluationService : IEvaluationService
{
    private readonly IMapper _mapper;
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAssessmentItemRepository _assessmentItemRepository;
    private readonly IAccessService _accessService;
    private readonly IAssessmentFeedbackGenerator _assessmentFeedbackGenerator;
    private readonly IKnowledgeComponentsUnitOfWork _unitOfWork;

    public EvaluationService(IMapper mapper, IKnowledgeMasteryRepository knowledgeMasteryRepository,
        IAssessmentItemRepository assessmentItemRepository, IAccessService accessService,
        IKnowledgeComponentsUnitOfWork unitOfWork, IAssessmentFeedbackGenerator assessmentFeedbackGenerator)
    {
        _mapper = mapper;
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _assessmentItemRepository = assessmentItemRepository;
        _accessService = accessService;
        _assessmentFeedbackGenerator = assessmentFeedbackGenerator;
        _unitOfWork = unitOfWork;
    }

    public Result<FeedbackDto> EvaluateAssessmentItemSubmission(int assessmentItemId, SubmissionDto submission, int learnerId)
    {
        var assessmentItem = _assessmentItemRepository.GetDerivedAssessmentItem(assessmentItemId);
        if (assessmentItem == null)
            return Result.Fail(FailureCode.NotFound);
        if (!_accessService.IsEnrolledInKc(assessmentItem.KnowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);
        
        var kcMastery = _knowledgeMasteryRepository.GetFull(assessmentItem.KnowledgeComponentId, learnerId);
        var domainSubmission = _mapper.Map<Submission>(submission);
        
        var feedback = _assessmentFeedbackGenerator.CreateFeedback(
            kcMastery.AssessmentItemMasteries.Find(m => m.AssessmentItemId == assessmentItemId),
            assessmentItem, domainSubmission);
        if (feedback.IsFailed) return Result.Fail(feedback.Errors);

        var result = RecordSubmission(kcMastery, assessmentItemId, domainSubmission, feedback.Value);
        if (result.IsFailed) return result;

        return _mapper.Map<FeedbackDto>(feedback.Value);
    }

    private Result RecordSubmission(KnowledgeComponentMastery kcMastery, int itemId, Submission submission, Feedback feedback)
    {
        if (feedback.FeedbackType == FeedbackType.Hint) kcMastery.RecordAssessmentItemHintRequest(itemId, feedback.Hint.Markdown);
        kcMastery.RecordAssessmentItemAnswerSubmission(itemId, submission, feedback);
        _knowledgeMasteryRepository.Update(kcMastery);
        return _unitOfWork.Save();
    }
}