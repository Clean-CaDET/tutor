﻿using FluentResults;
using System.Collections.Generic;
using Tutor.Core.Domain.Knowledge.InstructionalItems;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
{
    public class SessionService : ISessionService
    {
        private readonly IKcMasteryRepository _kcMasteryRepository;

        public SessionService(IKcMasteryRepository ikcMasteryRepository)
        {
            _kcMasteryRepository = ikcMasteryRepository;
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

            var result = kcMastery.RecordInstructionalItemSelection();
            if (result.IsFailed) return result.ToResult<List<InstructionalItem>>();

            _kcMasteryRepository.UpdateKcMastery(kcMastery);

            return Result.Ok(kcMastery.KnowledgeComponent.GetOrderedInstructionalItems());
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