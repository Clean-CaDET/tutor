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
            var assessmentEvent = _assessmentEventRepository.GetDerivedAssessmentEvent(submission.AssessmentEventId);
            if (assessmentEvent == null)
                return Result.Fail("No assessment event with ID: " + submission.AssessmentEventId);

            var knowledgeComponentMastery = _kcRepository
                .GetKnowledgeComponentMastery(submission.LearnerId, assessmentEvent.KnowledgeComponentId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("The Learner isn't enrolled to knowledge component with ID: " + assessmentEvent.KnowledgeComponentId);

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