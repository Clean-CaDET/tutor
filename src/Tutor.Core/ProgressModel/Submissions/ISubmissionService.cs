using System.Collections.Generic;
using Tutor.Core.ContentModel.LearningObjects.ArrangeTasks;
using Tutor.Core.ContentModel.LearningObjects.Challenges;
using Tutor.Core.ContentModel.LearningObjects.Questions;

namespace Tutor.Core.ProgressModel.Submissions
{
    public interface ISubmissionService
    {
        ChallengeEvaluation EvaluateChallenge(ChallengeSubmission submission);
        List<AnswerEvaluation> EvaluateAnswers(QuestionSubmission submission);
        List<ArrangeTaskContainerEvaluation> EvaluateArrangeTask(ArrangeTaskSubmission submission);
    }
}