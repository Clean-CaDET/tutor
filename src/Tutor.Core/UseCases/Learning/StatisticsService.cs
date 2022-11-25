using FluentResults;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.UseCases.Learning
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IKnowledgeMasteryRepository _knowledgeMasteryRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public StatisticsService(IKnowledgeMasteryRepository knowledgeMasteryRepository, IEnrollmentRepository enrollmentRepository)
        {
            _knowledgeMasteryRepository = knowledgeMasteryRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        public Result<KcMasteryStatistics> GetKcMasteryStatistics(int knowledgeComponentId, int learnerId)
        {
            if (!_enrollmentRepository.HasActiveEnrollmentForKc(knowledgeComponentId, learnerId))
                return Result.Fail(FailureCode.NoActiveEnrollment);

            var kcMastery = _knowledgeMasteryRepository.GetFullKcMastery(knowledgeComponentId, learnerId);
            if (kcMastery == null) return Result.Fail(FailureCode.NoKnowledgeComponent);

            return Result.Ok(kcMastery.Statistics);
        }

        public Result<double> GetMaxAssessmentCorrectness(int assessmentItemId, int learnerId)
        {
            var kcm = _knowledgeMasteryRepository.GetKcMasteryForAssessmentItem(assessmentItemId, learnerId);
            var itemMastery = kcm.AssessmentItemMasteries.Find(am => am.AssessmentItemId == assessmentItemId);
            return Result.Ok(itemMastery?.Mastery ?? 0.0);
        }
    }
}
