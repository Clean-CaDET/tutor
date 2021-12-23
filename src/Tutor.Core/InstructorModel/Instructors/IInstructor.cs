using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.InstructorModel.Instructors
{
    public interface IInstructor
    {
        Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponentId, int learnerId);

        void UpdateKcMastery(Submission submission, int knowledgeComponentId);
    }
}