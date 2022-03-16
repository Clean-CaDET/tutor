using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public class AssessmentEventInteractionService : IAssessmentEventInteractionService
    {
        private readonly IAssessmentEventRepository _assessmentEventRepository;
        private readonly IKCRepository _kcRepository;

        public AssessmentEventInteractionService(IAssessmentEventRepository assessmentEventRepository, IKCRepository kcRepository)
        {
            _assessmentEventRepository = assessmentEventRepository;
            _kcRepository = kcRepository;
        }

        public Result Interact(int learnerId, int assessmentEventId, AssessmentEventInteraction interaction)
        {
            var assessmentEvent = _assessmentEventRepository.GetDerivedAssessmentEvent(assessmentEventId);
            if (assessmentEvent == null)
                return Result.Fail("No assessment event with ID: " + assessmentEventId);

            var knowledgeComponentMastery = _kcRepository.GetKnowledgeComponentMastery(learnerId, assessmentEvent.KnowledgeComponentId);
            if (knowledgeComponentMastery == null)
                return Result.Fail("The Learner isn't enrolled to knowledge component with ID: " + assessmentEvent.KnowledgeComponentId);

            var result = knowledgeComponentMastery.InteractWithAssessmentEvent(assessmentEventId, interaction);

            _kcRepository.UpdateKCMastery(knowledgeComponentMastery);

            return result;
        }
    }
}
