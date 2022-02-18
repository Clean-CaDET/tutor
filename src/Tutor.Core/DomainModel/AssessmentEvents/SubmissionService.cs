using FluentResults;
using System;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IAssessmentEventRepository _assessmentEventRepository;
        private readonly IKCRepository _kcRepository;

        public SubmissionService(IAssessmentEventRepository assessmentEventRepository, IKCRepository kcRepository)
        {
            _assessmentEventRepository = assessmentEventRepository;
            _kcRepository = kcRepository;
        }

        public Result<Evaluation> EvaluateAndSaveSubmission(Submission submission)
        {
            var assessmentEvent = _assessmentEventRepository.GetDerivedAssessmentEvent(submission.AssessmentEventId);
            if (assessmentEvent == null)
                return Result.Fail("No assessment event with ID: " + submission.AssessmentEventId);

            Evaluation evaluation;
            try
            {
                evaluation = assessmentEvent.EvaluateSubmission(submission);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(e.Message);
            }

            if (evaluation.Correct) submission.MarkCorrect();
            submission.CorrectnessLevel = evaluation.CorrectnessLevel;

            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(submission.LearnerId, assessmentEvent.KnowledgeComponentId);
            knowledgeComponentMastery.UpdateKcMastery(submission);
            _kcRepository.UpdateKCMastery(knowledgeComponentMastery);
            _assessmentEventRepository.SaveSubmission(submission);

            return Result.Ok(evaluation);
        }
    }
}