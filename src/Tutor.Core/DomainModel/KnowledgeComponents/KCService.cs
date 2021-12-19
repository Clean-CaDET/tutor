using System;
using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KCService : IKCService
    {
        private readonly IKCRepository _ikcRepository;
        private readonly IAssessmentEventRepository _assessmentEventRepository;

        public KCService(IKCRepository ikcRepository, IAssessmentEventRepository assessmentEventRepository)
        {
            _ikcRepository = ikcRepository;
            _assessmentEventRepository = assessmentEventRepository;
        }

        public Result<List<Unit>> GetUnits()
        {
            return Result.Ok(_ikcRepository.GetUnits());
        }

        public Result<Unit> GetUnit(int id)
        {
            return Result.Ok(_ikcRepository.GetUnit(id));
        }

        public Result<KnowledgeComponent> GetKnowledgeComponentById(int id)
        {
            var knowledgeComponent = _ikcRepository.GetKnowledgeComponent(id);
            if (knowledgeComponent == null) return Result.Fail("No KC with index: " + id);
            return Result.Ok(knowledgeComponent);
        }

        public Result<List<AssessmentEvent>> GetAssessmentEventsByKnowledgeComponent(int id)
        {
            return Result.Ok(_ikcRepository.GetAssessmentEventsByKnowledgeComponent(id));
        }

        public Result<List<InstructionalEvent>> GetInstructionalEventsByKnowledgeComponent(int id)
        {
            return Result.Ok(_ikcRepository.GetInstructionalEventsByKnowledgeComponent(id));
        }

        public void UpdateKCMastery(Submission submission, Evaluation evaluation)
        {
            var currentCorrectnessLevel = _assessmentEventRepository
                .FindSubmissionWithMaxCorrectness(submission.AssessmentEventId).CorrectnessLevel;

            if (!(evaluation.CorrectnessLevel > currentCorrectnessLevel)) return;
            
            submission.SetCorrectnessLevel(evaluation.CorrectnessLevel);
            _assessmentEventRepository.SaveSubmission(submission);
            
            var assessmentEvent = _assessmentEventRepository
                .GetAssessmentEvent(submission.AssessmentEventId);
            var kcCount = _ikcRepository
                .GetAssessmentEventsByKnowledgeComponent(assessmentEvent.KnowledgeComponentId).Count;

            var mastery = ((100.0 / kcCount) * (evaluation.CorrectnessLevel - currentCorrectnessLevel)) / 100.0;
            var kcMastery = _ikcRepository.GetKnowledgeComponentMastery(submission.LearnerId, assessmentEvent.KnowledgeComponentId);
            _ikcRepository.UpdateKCMastery(kcMastery.Id, mastery);
        }
    }
}