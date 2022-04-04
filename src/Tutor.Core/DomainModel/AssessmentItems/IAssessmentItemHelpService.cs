using FluentResults;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public interface IAssessmentItemHelpService
    {
        Result SeekChallengeHints(int learnerId, int assessmentItemId);
        Result SeekChallengeSolution(int learnerId, int assessmentItemId);
    }
}
