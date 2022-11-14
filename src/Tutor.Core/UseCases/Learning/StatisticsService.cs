using FluentResults;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IKcMasteryRepository _kcMasteryRepository;

        public StatisticsService(IKcMasteryRepository kcMasteryRepository)
        {
            _kcMasteryRepository = kcMasteryRepository;
        }

        public Result<KcMasteryStatistics> GetKcMasteryStatistics(int knowledgeComponentId, int learnerId)
        {
            var kcMastery = _kcMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail("Learner not enrolled in KC: " + knowledgeComponentId);

            return Result.Ok(kcMastery.Statistics);
        }

        public Result<double> GetMaxAssessmentCorrectness(int learnerId, int assessmentItemId)
        {
            var kcm = _kcMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
            var itemMastery = kcm.AssessmentItemMasteries.Find(am => am.AssessmentItemId == assessmentItemId);
            return Result.Ok(itemMastery?.Mastery ?? 0.0);
        }
    }
}
