using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public class LearnerKcMasteryService : ILearnerKcMasteryService
    {
        private readonly IKcRepository _kcRepository;
        private readonly IAssessmentItemSelector _assessmentItemSelector;

        public LearnerKcMasteryService(IKcRepository ikcRepository, IAssessmentItemSelector assessmentItemSelector)
        {
            _kcRepository = ikcRepository;
            _assessmentItemSelector = assessmentItemSelector;
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

        public Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId)
        {
            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, knowledgeComponentId);
            var instructionalItems = _kcRepository.GetInstructionalItems(knowledgeComponentId);

            var result = knowledgeComponentMastery.RecordInstructionalItemSelection();
            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result.IsFailed ? result.ToResult<List<InstructionalItem>>() : Result.Ok(instructionalItems);
        }

        public Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId)
        {
            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, knowledgeComponentId);
            var result = knowledgeComponentMastery.SelectSuitableAssessmentItem(_assessmentItemSelector);
            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result.IsFailed ? result : Result.Ok(_kcRepository.GetDerivedAssessmentItem(result.Value.Id));
        }

        public Result<KnowledgeComponentStatistics> GetKnowledgeComponentStatistics(int learnerId, int knowledgeComponentId)
        {
            var mastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, knowledgeComponentId);
            var assessmentItems = mastery.KnowledgeComponent.AssessmentItems;

            var countCompleted = assessmentItems.Count(ae => ae.IsCompleted);
            var countAttempted = assessmentItems.Count(ae => ae.IsAttempted);
            
            return Result.Ok(new KnowledgeComponentStatistics(
                mastery.Mastery, assessmentItems.Count, countCompleted, countAttempted, mastery.IsSatisfied));
        }

        public Result LaunchSession(int learnerId, int knowledgeComponentId)
        {
            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, knowledgeComponentId);
            var result = knowledgeComponentMastery.LaunchSession();
            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);
            return result;
        }

        public Result TerminateSession(int learnerId, int knowledgeComponentId)
        {
            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, knowledgeComponentId);
            var result = knowledgeComponentMastery.TerminateSession();
            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);
            return result;
        }
    }
}