using FluentResults;

namespace Tutor.Courses.Core.Domain;

public static class UnitFeedbackRequestor
{
    public static Result<UnitFeedbackRequest> ShouldRequestFeedback(Tuple<int, int> kcMasteryCount, Tuple<int, int> taskProgressCount, List<UnitProgressRating> ratings)
    {
        var totalItemsCount = kcMasteryCount.Item1 + taskProgressCount.Item1;
        var completedItemsCount = kcMasteryCount.Item2 + taskProgressCount.Item2;

        var lastRatingTime = ratings.Where(r => !r.IsLearnerInitiated).MaxBy(r => r.Created)?.Created;
        var ratedKcsCount = ratings.SelectMany(r => r.CompletedKcIds).Distinct().Count();
        var ratedTasksCount = ratings.SelectMany(r => r.CompletedTaskIds).Distinct().Count();
        var ratedItemsCount = ratedKcsCount + ratedTasksCount;

        if (ratedItemsCount >= completedItemsCount)
            return new UnitFeedbackRequest(false, false);
        if (HasSufficientlyProgressed(completedItemsCount, totalItemsCount, ratedItemsCount, lastRatingTime))
            return new UnitFeedbackRequest(
            kcMasteryCount.Item2 > ratedKcsCount,
            taskProgressCount.Item2 > ratedTasksCount
            );
        return new UnitFeedbackRequest(false, false);
    }

    private static bool HasSufficientlyProgressed(int completedItemsCount, int totalItemsCount, int ratedItemsCount, DateTime? lastRatingTime)
    {
        return completedItemsCount == totalItemsCount ||
               (lastRatingTime == null && completedItemsCount > ratedItemsCount + 1) ||
               completedItemsCount >= ratedItemsCount + 4 ||
               (completedItemsCount > ratedItemsCount && HoursHavePassed(lastRatingTime, 1.5)) ||
               (completedItemsCount == ratedItemsCount + 3 && HoursHavePassed(lastRatingTime, 1));
    }

    private static bool HoursHavePassed(DateTime? lastRatingTime, double hours)
    {
        if(lastRatingTime == null) return false;
        return DateTime.UtcNow - lastRatingTime > TimeSpan.FromHours(hours);
    }
}