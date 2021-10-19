using System.Collections.Generic;

namespace Tutor.Core.ProgressModel.Submissions
{
    public class QuestionSubmission : Submission
    {
        public List<int> SubmittedAnswerIds { get; private set; }
        public int QuestionId { get; private set; }

        private QuestionSubmission()
        {
        }

        public QuestionSubmission(int questionId, List<int> submittedAnswerIds)
        {
            QuestionId = questionId;
            SubmittedAnswerIds = submittedAnswerIds;
        }
    }
}