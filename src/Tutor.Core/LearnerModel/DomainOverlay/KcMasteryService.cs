using FluentResults;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

namespace Tutor.Core.LearnerModel.DomainOverlay
{
    public class KcMasteryService : IKcMasteryService
    {
        private readonly IKcMasteryRepository _kcMasteryRepository;
        private readonly IAssessmentItemSelector _assessmentItemSelector;

        public KcMasteryService(IKcMasteryRepository ikcMasteryRepository, IAssessmentItemSelector assessmentItemSelector)
        {
            _kcMasteryRepository = ikcMasteryRepository;
            _assessmentItemSelector = assessmentItemSelector;
        }

        public Result<List<KnowledgeUnit>> GetUnits(int learnerId)
        {
            return Result.Ok(_kcMasteryRepository.GetEnrolledUnits(learnerId));
        }

        public Result<KnowledgeUnit> GetUnit(int unitId, int learnerId)
        {
            return Result.Ok(_kcMasteryRepository.GetUnitWithKcs(unitId, learnerId));
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
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            kcMastery.RecordInstructionalItemSelection();
            _kcMasteryRepository.UpdateKcMastery(kcMastery);

            return Result.Ok(kcMastery.KnowledgeComponent.InstructionalItems.OrderBy(i => i.Order).ToList());
        }

        public Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            var result = kcMastery.SelectSuitableAssessmentItem(_assessmentItemSelector);
            _kcMasteryRepository.UpdateKcMastery(kcMastery);

            return result.IsFailed ? result : Result.Ok(_kcMasteryRepository.GetDerivedAssessmentItem(result.Value.Id));
        }

        public Result<KnowledgeComponentStatistics> GetKnowledgeComponentStatistics(int knowledgeComponentId,
            int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            var assessmentItems = kcMastery.KnowledgeComponent.AssessmentItems;

            var countCompleted = assessmentItems.Count(ae => ae.IsCompleted);
            var countAttempted = assessmentItems.Count(ae => ae.IsAttempted);
            
            return Result.Ok(new KnowledgeComponentStatistics(
                kcMastery.Mastery, assessmentItems.Count, countCompleted, countAttempted, kcMastery.IsSatisfied));
        }

        public Result LaunchSession(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            var result = kcMastery.LaunchSession();
            _kcMasteryRepository.UpdateKcMastery(kcMastery);
            return result;
        }

        public Result TerminateSession(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            var result = kcMastery.TerminateSession();
            _kcMasteryRepository.UpdateKcMastery(kcMastery);
            return result;
        }
    }
}