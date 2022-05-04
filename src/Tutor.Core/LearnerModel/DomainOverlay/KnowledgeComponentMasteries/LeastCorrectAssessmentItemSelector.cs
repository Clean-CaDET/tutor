using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class LeastCorrectAssessmentItemSelector : IAssessmentItemSelector
    {
        public Result<int> SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed)
        {
            if (assessmentMasteries == null || assessmentMasteries.Count == 0)
                return Result.Fail("No assessment item masteries available for selection.");

            if(assessmentMasteries.Count > 1) assessmentMasteries = RemoveLastSubmitted(assessmentMasteries);

            if (isPassed) return Result.Ok(FindLeastAttemptedItem(assessmentMasteries));

            var itemWithoutSubmission = FindItemWithoutSubmissions(assessmentMasteries);
            return Result.Ok(itemWithoutSubmission != 0 ? itemWithoutSubmission : FindMinCorrectnessItem(assessmentMasteries));
        }

        private static List<AssessmentItemMastery> RemoveLastSubmitted(List<AssessmentItemMastery> assessmentMasteries)
        {
            var retVal = new List<AssessmentItemMastery>(assessmentMasteries);
            var lastSubmitted = retVal.MaxBy(am => am.LastSubmissionTime);
            retVal.Remove(lastSubmitted);
            return retVal;
        }

        private static int FindLeastAttemptedItem(List<AssessmentItemMastery> assessmentMasteries)
        {
            return assessmentMasteries.MinBy(am => am.SubmissionCount).AssessmentItemId;
        }

        private static int FindItemWithoutSubmissions(List<AssessmentItemMastery> assessmentMasteries)
        {
            var noSubmissionItem = assessmentMasteries.FirstOrDefault(am => am.SubmissionCount == 0);
            return noSubmissionItem?.AssessmentItemId ?? 0;
        }

        private static int FindMinCorrectnessItem(List<AssessmentItemMastery> assessmentMasteries)
        {
            return assessmentMasteries.MinBy(am => am.Mastery).AssessmentItemId;
        }
    }
}