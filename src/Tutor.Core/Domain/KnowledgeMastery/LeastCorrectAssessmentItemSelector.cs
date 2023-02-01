using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.Domain.KnowledgeMastery;

public class LeastCorrectAssessmentItemSelector : IAssessmentItemSelector
{
    public int SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed)
    {
        if (assessmentMasteries == null || assessmentMasteries.Count == 0) throw new ArgumentException("Empty AI mastery list.");

        if (assessmentMasteries.Count > 1) assessmentMasteries = RemoveLastSubmitted(assessmentMasteries);

        if (isPassed) return FindItemWithOldestAttempt(assessmentMasteries);

        var itemWithoutSubmission = FindItemWithoutSubmissions(assessmentMasteries);
        return itemWithoutSubmission != 0 ? itemWithoutSubmission : FindMinCorrectnessItem(assessmentMasteries);
    }

    private static List<AssessmentItemMastery> RemoveLastSubmitted(List<AssessmentItemMastery> assessmentMasteries)
    {
        var retVal = new List<AssessmentItemMastery>(assessmentMasteries);
        var lastSubmitted = retVal.MaxBy(am => am.LastSubmissionTime);
        retVal.Remove(lastSubmitted);
        return retVal;
    }

    private static int FindItemWithOldestAttempt(List<AssessmentItemMastery> assessmentMasteries)
    {
        return assessmentMasteries.MinBy(am => am.LastSubmissionTime).AssessmentItemId;
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