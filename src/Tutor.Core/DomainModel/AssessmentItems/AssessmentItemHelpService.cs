using FluentResults;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.DomainModel.KnowledgeComponents.Events.AssessmentItemEvents;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public class AssessmentItemHelpService : IAssessmentItemHelpService
    {
        private readonly IKcRepository _kcRepository;

        public AssessmentItemHelpService(IKcRepository kcRepository)
        {
            _kcRepository = kcRepository;
        }

        public Result SeekChallengeHints(int learnerId, int assessmentItemId)
        {
            return SeekHelp(new SoughtHints()
            {
                LearnerId = learnerId,
                AssessmentItemId = assessmentItemId
            });
        }

        public Result SeekChallengeSolution(int learnerId, int assessmentItemId)
        {
            return SeekHelp(new SoughtSolution()
            {
                LearnerId = learnerId,
                AssessmentItemId = assessmentItemId
            });
        }

        private Result SeekHelp(SoughtHelp helpEvent)
        {
            var knowledgeComponentMastery = _kcRepository
                 .GetKnowledgeComponentMasteryByAssessmentItem(helpEvent.LearnerId, helpEvent.AssessmentItemId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("Cannot seek help for AE with ID: " + helpEvent.AssessmentItemId);

            var result = knowledgeComponentMastery.SeekHelpForAssessmentItem(helpEvent);

            _kcRepository.UpdateKcMastery(knowledgeComponentMastery);

            return result;
        }
    }
}
