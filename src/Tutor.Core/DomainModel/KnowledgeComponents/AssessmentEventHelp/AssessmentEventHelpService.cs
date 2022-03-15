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

        public Result SeekHelp(int learnerId, int assessmentEventId, string helpType)
        {
            var assessmentEvent = _assessmentEventRepository.GetDerivedAssessmentEvent(assessmentEventId);
            if (assessmentEvent == null)
                return Result.Fail("No assessment event with ID: " + assessmentEventId);

            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, assessmentEvent.KnowledgeComponentId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("The Learner isn't enrolled to knowledge component with ID: " + assessmentEvent.KnowledgeComponentId);

            var result = knowledgeComponentMastery.SeekHelpForAssessmentEvent(assessmentEventId, helpType);

            _kcRepository.UpdateKCMastery(knowledgeComponentMastery);

            return result;
        }
    }
}
