using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.InstructorModel.Instructors
{
    public class DefaultInstructor : IInstructor
    {
        public DefaultInstructor()
        {
            //TODO: Repos
        }

        public Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId)
        {
            //TODO: Examine which AEs the learner has (not) completed for the given KC
            //TODO: Select the most suitable non-completed AE (advanced instructors can consider difficulty and other factors).
            throw new System.NotImplementedException();
        }
    }
}