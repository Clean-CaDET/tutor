using FluentResults;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;

        public StatisticsService(IKnowledgeMasteryRepository knowledgeMasteryRepository)
        {
            _knowledgeMasteryRepository = knowledgeMasteryRepository;
        }

        public Result<KcMasteryStatistics> GetKcMasteryStatistics(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _knowledgeMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            return Result.Ok(kcMastery.Statistics);
        }

        public Result<double> GetMaxAssessmentCorrectness(int learnerId, int assessmentItemId)
        {
            var kcm = _knowledgeMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
            var itemMastery = kcm.AssessmentItemMasteries.Find(am => am.AssessmentItemId == assessmentItemId);
            return Result.Ok(itemMastery?.Mastery ?? 0.0);
        }
    }
}
