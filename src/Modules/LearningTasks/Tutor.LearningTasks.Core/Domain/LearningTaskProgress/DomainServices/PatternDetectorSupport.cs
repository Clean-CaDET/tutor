using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepSupportEvents;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.DomainServices;

public class PatternDetectorSupport : INegativePatternDetector
{
    public List<string> Detect(List<TaskEvent> eventsUpToGraded, LearningTask task)
    {
        var insufficientlyTriedSteps = new HashSet<int>();
        foreach (var step in task.Steps!)
        {
            var stepEvents = eventsUpToGraded
                .Where(e => e is StepEvent stepEvent && stepEvent.StepId == step.Id)
                .ToList();

            var firstOpenedIndex = stepEvents.FindIndex(e => e is StepOpened);
            var firstSubmittedIndex = stepEvents.FindIndex(e => e is StepSubmitted);

            var timeOnSupport = 0.0;
            for (var i = firstOpenedIndex; i < firstSubmittedIndex - 2; i++)
            {
                if (stepEvents[i] is not SubmissionOpened) continue;
                if (stepEvents[i + 1] is not StepSupportEvent) continue;

                var nextNonSupportEventIndex = stepEvents.FindIndex(i + 2, e => e is not StepSupportEvent);
                if (nextNonSupportEventIndex == -1) continue;

                var timeBeforeSupport = (stepEvents[i + 1].TimeStamp - stepEvents[i].TimeStamp).TotalMinutes;
                timeOnSupport += (stepEvents[nextNonSupportEventIndex].TimeStamp - stepEvents[i + 1].TimeStamp).TotalMinutes;
                if (timeBeforeSupport < 3 && timeOnSupport > 2)
                {
                    insufficientlyTriedSteps.Add(step.Id);
                }
            }
        }

        var negativePatterns = new List<string>();
        var insufficientTryRatio = (double)insufficientlyTriedSteps.Count / task.Steps.Count;
        if (insufficientTryRatio > 0.4)
        {
            negativePatterns.Add($"Nedovoljan početni napor: Za {Math.Round(insufficientTryRatio * 100)}% koraka je gledao smernice/primere u roku od 3 minuta.");
        }

        return negativePatterns;
    }
}