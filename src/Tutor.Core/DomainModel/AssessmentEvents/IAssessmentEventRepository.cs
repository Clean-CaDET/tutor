using System.Collections.Generic;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public interface IAssessmentEventRepository
    {
        AssessmentEvent GetDerivedAssessmentEvent(int assessmentEventId);

        public List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponent(int id);

        public List<AssessmentEvent> GetAssessmentEventsWithLearnerSubmissions(int knowledgeComponentId,
            int learnerId);

        Submission FindSubmissionWithMaxCorrectness(int assessmentEventId, int learnerId);
    }
}