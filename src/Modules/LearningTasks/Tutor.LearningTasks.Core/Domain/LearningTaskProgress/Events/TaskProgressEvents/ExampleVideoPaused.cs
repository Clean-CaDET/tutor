namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
public class ExampleVideoPaused : TaskProgressEvent
{
    public ExampleVideoPaused(int stepId, string videoUrl)
    {
        StepId = stepId;
        VideoUrl = videoUrl;
    }

    public int StepId { get; private set; }

    public string VideoUrl { get; private set; }
}