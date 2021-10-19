using Tutor.Core.ProgressModel.Submissions;

namespace Tutor.Core.ProgressModel
{
    public interface ISubmissionRepository
    {
        void SaveChallengeSubmission(ChallengeSubmission challengeSubmission);
        void SaveQuestionSubmission(QuestionSubmission submission);
        void SaveArrangeTaskSubmission(ArrangeTaskSubmission submission);
        string GetWorkspacePath(int learnerId);
    }
}