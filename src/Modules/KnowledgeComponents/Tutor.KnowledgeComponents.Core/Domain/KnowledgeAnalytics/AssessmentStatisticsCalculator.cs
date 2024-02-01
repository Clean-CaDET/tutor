using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeAnalytics;

public class AssessmentStatisticsCalculator
{
    public AiStatistics Calculate(int aiId, List<AssessmentItemEvent> events)
    {
        var eventsGroupedByLearner = events
            .Where(e => e.AssessmentItemId == aiId)
            .GroupBy(e => e.LearnerId)
            .ToList();

        var minutesToCompletion = eventsGroupedByLearner
            .Select(CalculateCompletionTime).Where(completionTime => completionTime != 0).ToList();

        var attemptsToPass = eventsGroupedByLearner
            .Select(CalculateAttemptsToPass).Where(completionTime => completionTime != 0).ToList();

        return new AiStatistics
        {
            AiId = aiId,
            KcId = eventsGroupedByLearner.First().First().KnowledgeComponentId,
            MinutesToCompletion = minutesToCompletion,
            AttemptsToPass = attemptsToPass
        };
    }

    private static double CalculateCompletionTime(IEnumerable<AssessmentItemEvent> events)
    {
        var aiEvents = events.ToList();
        var firstAiCompletion = aiEvents.OfType<AssessmentItemAnswered>().FirstOrDefault();

        if (firstAiCompletion == null) return 0;

        return CalculateMinuteDifference(firstAiCompletion, aiEvents.First());
    }

    private static int CalculateAttemptsToPass(IEnumerable<AssessmentItemEvent> events)
    {
        var aiEvents = events.ToList();
        var firstAiPass = aiEvents.OfType<AssessmentItemAnswered>().FirstOrDefault(e => e.Feedback.Evaluation.Correct);

        if (firstAiPass == null) return 0;

        return aiEvents.OfType<AssessmentItemAnswered>().Count(e => e.TimeStamp <= firstAiPass.TimeStamp);
    }

    private static double CalculateMinuteDifference(DomainEvent secondEvent, DomainEvent firstEvent)
    {
        return Math.Round((secondEvent.TimeStamp - firstEvent.TimeStamp).TotalMinutes, 2);
    }
}