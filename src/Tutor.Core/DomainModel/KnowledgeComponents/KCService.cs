﻿using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KcService : IKCService
    {
        private readonly IKCRepository _kcRepository;
        private readonly IAssessmentEventRepository _assessmentEventRepository;
        private readonly IAssessmentEventSelector _assessmentEventSelector;

        public KcService(IKCRepository ikcRepository,
            IAssessmentEventRepository assessmentEventRepository,
            IAssessmentEventSelector assessmentEventSelector)
        {
            _kcRepository = ikcRepository;
            _assessmentEventRepository = assessmentEventRepository;
            _assessmentEventSelector = assessmentEventSelector;
        }

        public Result<List<Unit>> GetUnits()
        {
            return Result.Ok(_kcRepository.GetUnits());
        }

        public Result<Unit> GetUnit(int id, int learnerId)
        {
            return Result.Ok(_kcRepository.GetUnit(id, learnerId));
        }

        public Result<KnowledgeComponent> GetKnowledgeComponentById(int id)
        {
            var knowledgeComponent = _kcRepository.GetKnowledgeComponent(id);
            if (knowledgeComponent == null) return Result.Fail("No KC with index: " + id);
            return Result.Ok(knowledgeComponent);
        }

        public Result<List<AssessmentEvent>> GetAssessmentEventsByKnowledgeComponent(int id)
        {
            return Result.Ok(_assessmentEventRepository.GetAssessmentEventsByKnowledgeComponent(id));
        }

        public Result<List<InstructionalEvent>> GetInstructionalEventsByKnowledgeComponent(int id)
        {
            return Result.Ok(_kcRepository.GetInstructionalEventsByKnowledgeComponent(id));
        }

        public Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId)
        {
            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, knowledgeComponentId);
            var result = knowledgeComponentMastery.SelectSuitableAssessmentEvent(_assessmentEventSelector);
            _kcRepository.UpdateKCMastery(knowledgeComponentMastery);
            return result;             
        }

        public Result<KnowledgeComponentStatistics> GetKnowledgeComponentStatistics(int learnerId, int knowledgeComponentId)
        {
            var mastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, knowledgeComponentId);
            var assessmentEvents = _assessmentEventRepository.GetAssessmentEventsWithLearnerSubmissions(knowledgeComponentId, learnerId);
            
            var numberOfAssessmentEvents = assessmentEvents.Count;
            var numberOfCompletedAssessmentEvents = 0;
            numberOfCompletedAssessmentEvents += assessmentEvents.Where(ae => ae.Submissions.Count != 0)
                .Count(ae => ae.Submissions.OrderBy(sub => sub.CorrectnessLevel).Last().CorrectnessLevel >= 0.9);
            var numberOfTriedAssessmentEvents = numberOfAssessmentEvents - assessmentEvents.FindAll(ae => ae.Submissions.Count == 0).Count;
            
            return Result.Ok(new KnowledgeComponentStatistics(mastery.Mastery, numberOfAssessmentEvents,
                numberOfCompletedAssessmentEvents, numberOfTriedAssessmentEvents, mastery.IsSatisfied));
        }
    }
}