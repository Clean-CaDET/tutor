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
        private readonly IKcMasteryRepository _kcMasteryRepository;
        private readonly IAssessmentItemSelector _assessmentItemSelector;

        public LearnerKcMasteryService(IKcMasteryRepository ikcMasteryRepository, IAssessmentItemSelector assessmentItemSelector)
        {
            _kcMasteryRepository = ikcMasteryRepository;
            _assessmentItemSelector = assessmentItemSelector;
        }

        public Result<List<Unit>> GetUnits()
        {
            return Result.Ok(_kcMasteryRepository.GetUnits());
        }

        public Result<Unit> GetUnit(int unitId, int learnerId)
        {
            return Result.Ok(_kcMasteryRepository.GetUnitWithKcs(unitId));
        }

        public Result<List<KnowledgeComponentMastery>> GetKnowledgeComponentMasteries(List<int> kcIds, int learnerId)
        {
            return Result.Ok(_kcMasteryRepository.GetBasicKcMasteries(kcIds, learnerId));
        }

        public Result<KnowledgeComponent> GetKnowledgeComponent(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetBasicKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);
            return Result.Ok(kcMastery.KnowledgeComponent);
        }

        public Result<List<InstructionalItem>> GetInstructionalItems(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetKcMasteryWithInstructionsAndAssessments(knowledgeComponentId, learnerId);

            var result = kcMastery.RecordInstructionalItemSelection();
            _kcMasteryRepository.UpdateKcMastery(kcMastery);

            return result.IsFailed ? result.ToResult<List<InstructionalItem>>() : Result.Ok(kcMastery.KnowledgeComponent.InstructionalItems);
        }

        public Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId)
        {
            var knowledgeComponentMastery = _kcMasteryRepository.GetKcMasteryWithInstructionsAndAssessments(knowledgeComponentId, learnerId);
            var result = knowledgeComponentMastery.SelectSuitableAssessmentItem(_assessmentItemSelector);
            _kcMasteryRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result.IsFailed ? result : Result.Ok(_kcMasteryRepository.GetDerivedAssessmentItem(result.Value.Id));
        }

        public Result<KnowledgeComponentStatistics> GetKnowledgeComponentStatistics(int knowledgeComponentId,
            int learnerId)
        {
            var mastery = _kcMasteryRepository.GetKcMasteryWithInstructionsAndAssessments(knowledgeComponentId, learnerId);
            var assessmentItems = mastery.KnowledgeComponent.AssessmentItems;

            var countCompleted = assessmentItems.Count(ae => ae.IsCompleted);
            var countAttempted = assessmentItems.Count(ae => ae.IsAttempted);
            
            return Result.Ok(new KnowledgeComponentStatistics(
                mastery.Mastery, assessmentItems.Count, countCompleted, countAttempted, mastery.IsSatisfied));
        }

        public Result LaunchSession(int knowledgeComponentId, int learnerId)
        {
            var knowledgeComponentMastery = _kcMasteryRepository.GetKcMasteryWithInstructionsAndAssessments(knowledgeComponentId, learnerId);
            var result = knowledgeComponentMastery.LaunchSession();
            _kcMasteryRepository.UpdateKcMastery(knowledgeComponentMastery);
            return result;
        }

        public Result TerminateSession(int knowledgeComponentId, int learnerId)
        {
            var knowledgeComponentMastery = _kcMasteryRepository.GetKcMasteryWithInstructionsAndAssessments(knowledgeComponentId, learnerId);
            var result = knowledgeComponentMastery.TerminateSession();
            _kcMasteryRepository.UpdateKcMastery(knowledgeComponentMastery);
            return result;
        }
    }
}