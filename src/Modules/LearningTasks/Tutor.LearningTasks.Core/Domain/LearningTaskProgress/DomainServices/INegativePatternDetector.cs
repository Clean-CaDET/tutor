using Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskEvents;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.DomainServices;

internal interface INegativePatternDetector
{
    List<string> Detect(List<TaskEvent> eventsUpToGraded, LearningTask task);
}