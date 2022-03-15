using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.DomainModel.KnowledgeComponents.AssessmentEventHelp
{
    public class AssessmentEventHelpService : IAssessmentEventHelpService
    {
        private readonly IAssessmentEventRepository _assessmentEventRepository;
        private readonly IKCRepository _kcRepository;

        public AssessmentEventHelpService(IAssessmentEventRepository assessmentEventRepository, IKCRepository kcRepository)
        {
            _assessmentEventRepository = assessmentEventRepository;
            _kcRepository = kcRepository;
        }

        public Result SeekChallengeHints(int learnerId, int assessmentEventId)
        {
            return SeekHelp(new SoughtHints()
            {
                LearnerId = learnerId,
                AssessmentEventId = assessmentEventId
            });
        }

        public Result SeekChallengeSolution(int learnerId, int assessmentEventId)
        {
            return SeekHelp(new SoughtSolution()
            {
                LearnerId = learnerId,
                AssessmentEventId = assessmentEventId
            });
        }

        private Result SeekHelp(SoughtHelp helpEvent)
        {
            var knowledgeComponentMastery = _kcRepository
                 .GetKnowledgeComponentMasteryByAssessmentEvent(helpEvent.LearnerId, helpEvent.AssessmentEventId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("Cannot seek help for AE with ID: " + helpEvent.AssessmentEventId);

            var result = knowledgeComponentMastery.SeekHelpForAssessmentEvent(helpEvent);

            _kcRepository.UpdateKCMastery(knowledgeComponentMastery);

            return result;
        }
    }
}
