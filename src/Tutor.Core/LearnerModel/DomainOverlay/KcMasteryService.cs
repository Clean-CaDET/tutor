﻿using FluentResults;
using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;

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
            var unit = _kcMasteryRepository.GetUnitWithKcs(unitId, learnerId);
            if (unit == null) return Result.Fail("Learner not enrolled in KC: " + unitId);

            return Result.Ok(unit);
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

            var result = kcMastery.SelectInstructionalItems();
            _kcMasteryRepository.UpdateKcMastery(kcMastery);

            return result;
        }

        public Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            var selectionResult = _assessmentItemSelector.SelectSuitableAssessmentItemId(kcMastery.AssessmentItemMasteries, kcMastery.IsPassed);
            if (selectionResult.IsFailed) return selectionResult.ToResult<AssessmentItem>();

            var masteryResult = kcMastery.RecordAssessmentItemInteraction(new AssessmentItemSelected()
            {
                AssessmentItemId = selectionResult.Value
            });
            if (masteryResult.IsFailed) return masteryResult.ToResult<AssessmentItem>();

            _kcMasteryRepository.UpdateKcMastery(kcMastery);

            return Result.Ok(_kcMasteryRepository.GetDerivedAssessmentItem(selectionResult.Value));
        }

        public Result<KcMasteryStatistics> GetKcMasteryStatistics(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            return Result.Ok(kcMastery.Statistics);
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