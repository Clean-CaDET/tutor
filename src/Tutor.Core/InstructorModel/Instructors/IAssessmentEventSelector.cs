using FluentResults;
using Tutor.Core.DomainModel.AssessmentEvents;

namespace Tutor.Core.InstructorModel.Instructors
{
    public interface IAssessmentEventSelector
    {
        Result<AssessmentEvent> SelectSuitableAssessmentEvent(int knowledgeComponent, int learnerId);

        // void UpdateKcMastery(Submission submission, int knowledgeComponentId);
    }
}