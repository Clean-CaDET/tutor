using FluentResults;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public interface IAssessmentEventInteractionService
    {
        Result Interact(int learnerId, int assessmentEventId, AssessmentEventInteraction interaction);
    }
}
