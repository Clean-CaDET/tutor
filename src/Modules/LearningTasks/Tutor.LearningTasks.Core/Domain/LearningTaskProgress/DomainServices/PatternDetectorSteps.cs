using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepEvents;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepSupportEvents;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.DomainServices;

public class PatternDetectorSteps : INegativePatternDetector
{
    public List<string> Detect(List<TaskEvent> eventsUpToGraded, LearningTask task)
    {
        var negativePatterns = new List<string>();
        if (task.Steps!.Count == 1) return negativePatterns;

        var firstSubmissionIndex = eventsUpToGraded.FindIndex(e => e is StepSubmitted);

        var stepsWithReviewedSupport = new HashSet<int>();
        for (var i = 0; i < firstSubmissionIndex; i++)
        {
            if (eventsUpToGraded[i] is not StepSupportEvent supportEvent) continue;
            stepsWithReviewedSupport.Add(supportEvent.StepId);
        }

        if (stepsWithReviewedSupport.Count == task.Steps.Count)
        {
            negativePatterns.Add("Neefektivan rad: Pogledao je smernice/primere od svih koraka pre nego što je rešio bar 1 korak.");
        }

        return negativePatterns;
    }
}