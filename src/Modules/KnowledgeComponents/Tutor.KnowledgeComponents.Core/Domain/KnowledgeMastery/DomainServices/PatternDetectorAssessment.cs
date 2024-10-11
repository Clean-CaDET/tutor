using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

public class PatternDetectorAssessment : INegativePatternDetector
{
    public List<string> Detect(List<KnowledgeComponentEvent> eventsUpToSatisfied, KnowledgeComponent kc)
    {
        var passedQuestionCount = 0;
        var threePlusTriesBeforeCompletion = 0;

        for (var i = 0; i < eventsUpToSatisfied.Count - 1; i++)
        {
            if (eventsUpToSatisfied[i] is not AssessmentItemSelected assessmentSelected) continue;
            var matchingAnswer = FindMatchingCorrectAnswer(eventsUpToSatisfied, i, assessmentSelected.AssessmentItemId);
            if (matchingAnswer == null || !matchingAnswer.IsFirstCorrect) continue;

            passedQuestionCount++;
            if (matchingAnswer.AttemptCount >= 3) threePlusTriesBeforeCompletion++;
        }

        var rushedFirstAnswers = CountRushedFirstAnswers(eventsUpToSatisfied);

        var rushedAnswersRatio = Math.Round((double)rushedFirstAnswers / passedQuestionCount, 2);
        var manyTriesRatio = Math.Round((double)threePlusTriesBeforeCompletion / passedQuestionCount, 2);

        var negativePatterns = new List<string>();
        if (rushedAnswersRatio > 0.4)
        {
            negativePatterns.Add(
                $"Pogađanje ili brzanje: Od {passedQuestionCount} rešenih pitanja, za {rushedAnswersRatio * 100:F0}% daje pogrešan prvi odgovor u 30 sekundi od otvaranja pitanja.");
        }
        if (manyTriesRatio > 0.4)
        {
            negativePatterns.Add(
                $"Nepromišljenost: Od {passedQuestionCount} rešenih pitanja, {manyTriesRatio * 100:F0}% odgovara tačno tek posle 3 ili više pokušaja.");
        }

        return negativePatterns;
    }

    private static AssessmentItemAnswered? FindMatchingCorrectAnswer(List<KnowledgeComponentEvent> events, int i, int aiId)
    {
        for (var j = i + 1; j < events.Count; j++)
        {
            if (events[j] is AssessmentItemSelected) return null;
            if (events[j] is AssessmentItemAnswered e && e.AssessmentItemId == aiId && e.IsFirstCorrect) return e;
        }
        return null;
    }

    private static int CountRushedFirstAnswers(List<KnowledgeComponentEvent> eventsUpToSatisfied)
    {
        var rushedFirstAnswers = 0;
        for (var i = 0; i < eventsUpToSatisfied.Count - 1; i++)
        {
            if (eventsUpToSatisfied[i] is not AssessmentItemSelected assessmentSelected) continue;
            var matchingAnswer = FindMatchingAnswer(eventsUpToSatisfied, i, assessmentSelected.AssessmentItemId);
            if (matchingAnswer == null) continue;
            if (matchingAnswer.IsFirstCorrect || matchingAnswer.AttemptCount != 1) continue;
            if ((matchingAnswer.TimeStamp - assessmentSelected.TimeStamp).TotalMinutes > 0.5) continue;
            if (!QuestionIsPassed(eventsUpToSatisfied, assessmentSelected.AssessmentItemId)) continue;
            rushedFirstAnswers++;
        }

        return rushedFirstAnswers;
    }

    private static bool QuestionIsPassed(List<KnowledgeComponentEvent> eventsUpToSatisfied, int aiId)
    {
        return eventsUpToSatisfied.Any(e => e is AssessmentItemAnswered a && a.AssessmentItemId == aiId && a.IsFirstCorrect);
    }

    private static AssessmentItemAnswered? FindMatchingAnswer(List<KnowledgeComponentEvent> events, int i, int aiId)
    {
        for (var j = i + 1; j < events.Count; j++)
        {
            if (events[j] is AssessmentItemSelected) return null;
            if (events[j] is AssessmentItemAnswered e && e.AssessmentItemId == aiId) return e;
        }
        return null;
    }
}