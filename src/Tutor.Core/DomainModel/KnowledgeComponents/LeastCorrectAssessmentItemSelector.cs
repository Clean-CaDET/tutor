using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class LeastCorrectAssessmentItemSelector : IAssessmentItemSelector
    {
        public AssessmentItem SelectSuitableAssessmentItem(List<AssessmentItem> itemsWithSubmissions)
        {
            if (itemsWithSubmissions.Count == 0) return null;

            var aeNoSubmission = FindAeWithNoSubmission(itemsWithSubmissions);
            return aeNoSubmission ?? FindAeWithMinCorrectSubmission(itemsWithSubmissions);
        }

        private static AssessmentItem FindAeWithNoSubmission(List<AssessmentItem> assessmentItems)
        {
            return assessmentItems.OrderBy(ae => ae.Order).FirstOrDefault(ae => ae.Submissions.Count == 0);
        }

        private static AssessmentItem FindAeWithMinCorrectSubmission(List<AssessmentItem> assessmentItems)
        {
            var lastSubmissions = FindLastSubmissionForEachAe(assessmentItems);
            var maxCorrectnessSubmissions = FindMaxCorrectnessSubmissionForEachAe(assessmentItems);

            if (lastSubmissions.Count != 1)
            {
                // Remove last made submission to avoid giving the learner the same AE.
                var lastSubmission = lastSubmissions.OrderBy(sub => sub.TimeStamp).Last();
                lastSubmissions.Remove(lastSubmission);
                maxCorrectnessSubmissions.Remove(lastSubmission);
            }

            var submissionWithMinCorrectness = maxCorrectnessSubmissions.OrderBy(sub => sub.CorrectnessLevel).First();
            return assessmentItems.Find(ai => ai.Id == submissionWithMinCorrectness.AssessmentItemId);
        }

        private static List<Submission> FindLastSubmissionForEachAe(List<AssessmentItem> assessmentItems)
        {
            var lastSubmissions = new List<Submission>();

            foreach (var ae in assessmentItems)
            {
                lastSubmissions.Add(ae.Submissions.OrderBy(sub => sub.TimeStamp).Last());
            }

            return lastSubmissions;
        }

        private static List<Submission> FindMaxCorrectnessSubmissionForEachAe(List<AssessmentItem> assessmentItems)
        {
            var maxCorrectnessSubmissions = new List<Submission>();

            foreach (var ae in assessmentItems)
            {
                maxCorrectnessSubmissions.Add(ae.Submissions.OrderBy(sub => sub.CorrectnessLevel).Last());
            }

            return maxCorrectnessSubmissions;
        }
    }
}