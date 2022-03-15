using FluentResults;
using System;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;
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
            var knowledgeComponentMastery = _kcRepository
                 .GetKnowledgeComponentMasteryByAssessmentEvent(submission.LearnerId, submission.AssessmentEventId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("Cannot submit answer for AE with ID: " + submission.AssessmentEventId);

            var result = knowledgeComponentMastery.SubmitAEAnswer(submission);

            if (result.IsSuccess)
            {
                _kcRepository.UpdateKCMastery(knowledgeComponentMastery);
                _assessmentEventRepository.SaveSubmission(submission);
            }

            return result;
        }
    }
}