using FluentResults;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
{
    public class SessionService : ISessionService
    {
        private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;

        public SessionService(IKnowledgeMasteryRepository ikcMasteryRepository)
        {
            _knowledgeMasteryRepository = ikcMasteryRepository;
        }

        public Result LaunchSession(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _knowledgeMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            var result = kcMastery.LaunchSession();
            _knowledgeMasteryRepository.UpdateKcMastery(kcMastery);
            return result;
        }

        public Result TerminateSession(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _knowledgeMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            var result = kcMastery.TerminateSession();
            _knowledgeMasteryRepository.UpdateKcMastery(kcMastery);
            return result;
        }
    }
}