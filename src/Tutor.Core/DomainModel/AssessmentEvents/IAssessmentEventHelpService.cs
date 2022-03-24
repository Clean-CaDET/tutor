using FluentResults;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public interface IAssessmentEventHelpService
    {
        Result SeekChallengeHints(int learnerId, int assessmentEventId);
        Result SeekChallengeSolution(int learnerId, int assessmentEventId);
    }
}
