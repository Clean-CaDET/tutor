using System.Collections.Generic;
using System.Linq;
using FluentResults;
using Tutor.Core.DomainModel.AssessmentItems;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class LeastCorrectAssessmentItemSelector : IAssessmentItemSelector
    {
        private readonly IAssessmentItemRepository _assessmentItemRepository;

        public LeastCorrectAssessmentItemSelector(IAssessmentItemRepository assessmentItemRepository)
        {
            _assessmentItemRepository = assessmentItemRepository;
        }

        public Result<AssessmentItem> SelectSuitableAssessmentItem(int knowledgeComponentId, int learnerId)
        {
            var assessmentItems = _assessmentItemRepository.GetAssessmentItemsWithLearnerSubmissions(knowledgeComponentId, learnerId);
            if (assessmentItems.Count == 0) return Result.Fail("No available assessment events.");

            var aeNoSubmission = FindAeWithNoSubmission(assessmentItems);
            return Result.Ok(aeNoSubmission ?? FindAeWithMinCorrectSubmission(assessmentItems));
        }

        private AssessmentItem FindAeWithNoSubmission(List<AssessmentItem> assessmentItems)
        {
            var ae = assessmentItems.OrderBy(ae => ae.Order).FirstOrDefault(ae => ae.Submissions.Count == 0);
            return ae != null ? _assessmentItemRepository.GetDerivedAssessmentItem(ae.Id) : null;
        }

        private AssessmentItem FindAeWithMinCorrectSubmission(List<AssessmentItem> assessmentItems)
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
            return _assessmentItemRepository.GetDerivedAssessmentItem(submissionWithMinCorrectness.AssessmentItemId);
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