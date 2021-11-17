using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.Questions;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public interface IAssessmentEventRepository
    {
        Challenge GetChallenge(int submissionChallengeId);
        Question GetQuestion(int submissionQuestionId);
        ArrangeTask GetArrangeTask(int submissionArrangeTaskId);
    }
}
