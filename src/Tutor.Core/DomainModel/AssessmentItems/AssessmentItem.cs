using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.DomainModel.AssessmentItems
{
    public abstract class AssessmentItem
    {
        public int Id { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public int Order { get; private set; }
        public List<Submission> Submissions { get; private set; }
        public bool IsCompleted => Submissions.Any(s => s.IsCorrect);
        public bool IsAttempted => Submissions.Count > 0;

        protected AssessmentItem() {}

        protected AssessmentItem(int id, int knowledgeComponentId)
        {
            Id = id;
            KnowledgeComponentId = knowledgeComponentId;
        }

        public abstract Evaluation EvaluateSubmission(Submission submission);

        public double GetMaximumSubmissionCorrectness()
        {
            return Submissions.Any() ? Submissions.OrderBy(sub => sub.CorrectnessLevel).Last().CorrectnessLevel : 0.0;
        }
    }
}