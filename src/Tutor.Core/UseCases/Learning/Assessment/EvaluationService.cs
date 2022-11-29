using FluentResults;
using System;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.RepositoryInterfaces;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning.Assessment;

public class EvaluationService : IEvaluationService
{
    private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
    private readonly IAssessmentItemRepository _assessmentItemRepository;
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EvaluationService(IKnowledgeMasteryRepository knowledgeMasteryRepository, IAssessmentItemRepository assessmentItemRepository, IEnrollmentRepository enrollmentRepository)
    {
        _knowledgeMasteryRepository = knowledgeMasteryRepository;
        _assessmentItemRepository = assessmentItemRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public Result<Evaluation> EvaluateAssessmentItemSubmission(int assessmentItemId, Submission submission,
        int learnerId)
    {
        var assessmentItem = _assessmentItemRepository.GetDerivedAssessmentItem(assessmentItemId);
        if (assessmentItem == null) return Result.Fail(FailureCode.NotFound);

        if (!_enrollmentRepository.HasActiveEnrollmentForKc(assessmentItem.KnowledgeComponentId, learnerId))
            return Result.Fail(FailureCode.NotEnrolledInUnit);
            
        var kcMastery = _knowledgeMasteryRepository.GetFullKcMastery(assessmentItem.KnowledgeComponentId, learnerId);

        Evaluation evaluation;
        try
        {
            evaluation = assessmentItem.Evaluate(submission);
        }
        catch (ArgumentException ex)
        {
            return Result.Fail(FailureCode.InvalidAssessmentSubmission).WithError(ex.Message);
        }

        kcMastery.RecordAssessmentItemAnswerSubmission(assessmentItemId, submission, evaluation);
        _knowledgeMasteryRepository.UpdateKcMastery(kcMastery);

        return Result.Ok(evaluation);
    }
}