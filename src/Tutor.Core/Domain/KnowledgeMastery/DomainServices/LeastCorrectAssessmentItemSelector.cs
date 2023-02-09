using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutor.Core.Domain.KnowledgeMastery.DomainServices;

public class LeastCorrectAssessmentItemSelector : IAssessmentItemSelector
{
    public int SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed)
    {
        if (assessmentMasteries == null || assessmentMasteries.Count == 0) throw new ArgumentException("Empty AI mastery list.");

        if (isPassed) return FindItemWithOldestAttempt(assessmentMasteries);

        if (HasPreviousSubmissions(assessmentMasteries)) assessmentMasteries = RemoveLastSubmitted(assessmentMasteries);
        
        var itemWithoutSubmission = FindItemWithoutSubmissions(assessmentMasteries);
        return itemWithoutSubmission != 0 ? itemWithoutSubmission : FindMinCorrectnessItem(assessmentMasteries);
    }

    private static int FindItemWithOldestAttempt(List<AssessmentItemMastery> assessmentMasteries)
    {
        return assessmentMasteries.MinBy(am => am.LastSubmissionTime).AssessmentItemId;
    }

    private static bool HasPreviousSubmissions(List<AssessmentItemMastery> assessmentMasteries)
    {
        return assessmentMasteries.Count > 1 && assessmentMasteries.Any(m => m.LastSubmissionTime != null);
    }

    private static List<AssessmentItemMastery> RemoveLastSubmitted(List<AssessmentItemMastery> assessmentMasteries)
    {
        var retVal = new List<AssessmentItemMastery>(assessmentMasteries);
        var lastSubmitted = retVal.MaxBy(am => am.LastSubmissionTime);
        retVal.Remove(lastSubmitted);
        return retVal;
    }

    private static int FindItemWithoutSubmissions(List<AssessmentItemMastery> assessmentMasteries)
    {
        var noSubmissionItem = assessmentMasteries.FirstOrDefault(am => am.SubmissionCount == 0);
        return noSubmissionItem?.AssessmentItemId ?? 0;
    }

    private static int FindMinCorrectnessItem(List<AssessmentItemMastery> assessmentMasteries)
    {
        var minimumCorrectnessItem = assessmentMasteries.MinBy(am => am.Mastery);

        return minimumCorrectnessItem.IsPassed ? FindItemWithOldestAttempt(assessmentMasteries) : minimumCorrectnessItem.AssessmentItemId;
    }
}