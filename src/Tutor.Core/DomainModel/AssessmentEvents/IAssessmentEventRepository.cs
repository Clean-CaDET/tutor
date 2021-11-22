using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;

namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public interface IAssessmentEventRepository
    {
        Challenge GetChallenge(int submissionChallengeId);
        MRQContainer GetQuestion(int submissionQuestionId);
        ArrangeTask GetArrangeTask(int submissionArrangeTaskId);
    }
}
