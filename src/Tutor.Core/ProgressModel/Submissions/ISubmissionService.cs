using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.Challenges;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;

namespace Tutor.Core.ProgressModel.Submissions
{
    public interface ISubmissionService
    {
        ChallengeEvaluation EvaluateChallenge(ChallengeSubmission submission);
        List<AnswerEvaluation> EvaluateAnswers(QuestionSubmission submission);
        List<ArrangeTaskContainerEvaluation> EvaluateArrangeTask(ArrangeTaskSubmission submission);
    }
}