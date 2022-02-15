using System;
using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.InstructorModel.Instructors;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KCService : IKCService
    {
        private readonly IKCRepository _ikcRepository;
        private readonly IAssessmentEventRepository _assessmentEventRepository;
        private readonly KnowledgeComponentMastery _knowledgeComponentMastery;
        private readonly IAssessmentEventSelector _assessmentEventSelector;

        public KCService(IKCRepository ikcRepository,
            IAssessmentEventRepository assessmentEventRepository,
            KnowledgeComponentMastery knowledgeComponentMastery,
            IAssessmentEventSelector assessmentEventSelector)
        {
            _ikcRepository = ikcRepository;
            _assessmentEventRepository = assessmentEventRepository;
            _knowledgeComponentMastery = knowledgeComponentMastery;
            _assessmentEventSelector = assessmentEventSelector;
        }

        public Result<List<Unit>> GetUnits()
        {
            return Result.Ok(_ikcRepository.GetUnits());
        }

        public Result<Unit> GetUnit(int id, int learnerId)
        {
            return Result.Ok(_ikcRepository.GetUnit(id, learnerId));
        }

        public Result<KnowledgeComponent> GetKnowledgeComponentById(int id)
        {
            var knowledgeComponent = _ikcRepository.GetKnowledgeComponent(id);
            if (knowledgeComponent == null) return Result.Fail("No KC with index: " + id);
            return Result.Ok(knowledgeComponent);
        }

        public Result<List<AssessmentEvent>> GetAssessmentEventsByKnowledgeComponent(int id)
        {
            return Result.Ok(_assessmentEventRepository.GetAssessmentEventsByKnowledgeComponent(id));
        }

        public Result<List<InstructionalEvent>> GetInstructionalEventsByKnowledgeComponent(int id)
        {
            return Result.Ok(_ikcRepository.GetInstructionalEventsByKnowledgeComponent(id));
        }

        public Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId)
        {
            return _knowledgeComponentMastery.SelectSuitableAssessmentEvent(knowledgeComponentId, learnerId,
                _assessmentEventSelector);
        }
    }
}