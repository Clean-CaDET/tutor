namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

public class LeastCorrectAssessmentItemSelector : IAssessmentItemSelector
{
    public int SelectSuitableAssessmentItemId(List<AssessmentItemMastery> assessmentMasteries, bool isPassed)
    {
        if (assessmentMasteries == null || assessmentMasteries.Count == 0) throw new ArgumentException("Empty AI mastery list.");

        if (isPassed)
        {
            var minimumCorrectnessItem = assessmentMasteries.MinBy(am => am.Mastery);
            return minimumCorrectnessItem.IsPassed ? FindItemWithOldestAttempt(assessmentMasteries) : minimumCorrectnessItem.AssessmentItemId;
        }

        if (OneIsNotPassed(assessmentMasteries)) return FindMinCorrectnessItem(assessmentMasteries);

        if (AnyWereAttempted(assessmentMasteries)) assessmentMasteries = RemoveLastSubmitted(assessmentMasteries);
        var itemWithoutSubmission = FindItemWithoutSubmissions(assessmentMasteries);
        return itemWithoutSubmission != 0 ? itemWithoutSubmission : FindMinCorrectnessItem(assessmentMasteries);
    }

    private static int FindItemWithOldestAttempt(List<AssessmentItemMastery> assessmentMasteries)
    {
        var noSubmissionItem = FindItemWithoutSubmissions(assessmentMasteries);
        return noSubmissionItem != 0 ? noSubmissionItem : assessmentMasteries.MinBy(am => am.LastSubmissionTime).AssessmentItemId;
    }

    private static bool OneIsNotPassed(List<AssessmentItemMastery> assessmentMasteries)
    {
        return assessmentMasteries.Count(a => !a.IsPassed) == 1;
    }

    private static bool AnyWereAttempted(List<AssessmentItemMastery> assessmentMasteries)
    {
        return assessmentMasteries.Count > 1 && assessmentMasteries.Any(m => m.LastSubmissionTime != null);
    }

    private static List<AssessmentItemMastery> RemoveLastSubmitted(List<AssessmentItemMastery> assessmentMasteries)
    {
        var lastSubmitted = assessmentMasteries.MaxBy(am => am.LastSubmissionTime);
        return assessmentMasteries.Where(a => a.AssessmentItemId != lastSubmitted.AssessmentItemId).ToList();
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