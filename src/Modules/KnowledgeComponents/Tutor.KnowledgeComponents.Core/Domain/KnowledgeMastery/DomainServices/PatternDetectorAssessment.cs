using Tutor.KnowledgeComponents.Core.Domain.Knowledge;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.Events.AssessmentItemEvents;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

public class PatternDetectorAssessment : INegativePatternDetector
{
    public List<string> Detect(List<KnowledgeComponentEvent> eventsUpToSatisfied, KnowledgeComponent kc)
    {
        var completedQuestionCount = 0;
        var rushedFirstAnswers = 0;
        var threePlusTriesBeforeCompletion = 0;

        for (var i = 0; i < eventsUpToSatisfied.Count - 1; i++)
        {
            if (eventsUpToSatisfied[i] is not AssessmentItemSelected assessmentSelected) continue;
            var matchingAnswer = FindMatchingAnswer(eventsUpToSatisfied, i, assessmentSelected.AssessmentItemId);
            if (matchingAnswer == null) continue;

            if (matchingAnswer.IsFirstCorrect)
            {
                completedQuestionCount++;
                if (matchingAnswer.AttemptCount >= 3) threePlusTriesBeforeCompletion++;
                continue;
            }

            if (matchingAnswer.AttemptCount != 1) continue;
            if ((matchingAnswer.TimeStamp - assessmentSelected.TimeStamp).TotalMinutes > 0.5) continue;
            rushedFirstAnswers++;
        }

        var rushedAnswersRatio = Math.Round((double)rushedFirstAnswers / completedQuestionCount, 2);
        var manyTriesRatio = Math.Round((double)threePlusTriesBeforeCompletion / completedQuestionCount, 2);

        var negativePatterns = new List<string>();
        if (rushedAnswersRatio > 0.4)
        {
            negativePatterns.Add(
                $"Pogađanje ili brzanje: Od {completedQuestionCount} pitanja, za {rushedAnswersRatio * 100}% daje pogrešan prvi odgovor u 30 sekundi od otvaranja pitanja.");
        }
        if (manyTriesRatio > 0.4)
        {
            negativePatterns.Add(
                $"Nepromišljenost: Od {completedQuestionCount} pitanja, {manyTriesRatio * 100}% odgovara tačno tek posle 3 ili više pokušaja.");
        }

        return negativePatterns;

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