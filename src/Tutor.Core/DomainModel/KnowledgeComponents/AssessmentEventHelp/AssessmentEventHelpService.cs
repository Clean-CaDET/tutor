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
            var assessmentEvent = _assessmentEventRepository.GetDerivedAssessmentEvent(helpEvent.AssessmentEventId);
            if (assessmentEvent == null)
                return Result.Fail("No assessment event with ID: " + helpEvent.AssessmentEventId);

            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(helpEvent.LearnerId, assessmentEvent.KnowledgeComponentId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("The Learner isn't enrolled to knowledge component with ID: " + assessmentEvent.KnowledgeComponentId);

            var result = knowledgeComponentMastery.SeekHelpForAssessmentEvent(helpEvent);

            _kcRepository.UpdateKCMastery(knowledgeComponentMastery);

            return result;
        }
    }
}
