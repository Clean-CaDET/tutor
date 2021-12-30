using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public interface IAssessmentEventRepository
    {
        AssessmentEvent GetDerivedAssessmentEvent(int assessmentEventId);

        public List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponent(int id);

        public List<AssessmentEvent> GetAssessmentEventsWithLearnerSubmissions(int knowledgeComponentId,
            int learnerId);

        void SaveSubmission(Submission submission);

        Submission FindSubmissionWithMaxCorrectness(int assessmentEventId, int learnerId);

        int CountAssessmentEvents(int knowledgeComponentId);
    }
}