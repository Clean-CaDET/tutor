﻿using FluentResults;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IAssessmentEventRepository _assessmentEventRepository;
        private readonly IKcRepository _kcRepository;

        public SubmissionService(IAssessmentEventRepository assessmentEventRepository, IKcRepository kcRepository)
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

            var result = knowledgeComponentMastery.SubmitAssessmentEventAnswer(submission);   

            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result;
        }

        public Result<double> GetMaxCorrectness(int aeId, int learnerId)
        {
            var submission = _assessmentEventRepository.FindSubmissionWithMaxCorrectness(aeId, learnerId);
            return Result.Ok(submission?.CorrectnessLevel ?? 0.0);
        }
    }
}