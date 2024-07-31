namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.TaskProgressEvents;
public class ExampleVideoPlayed : TaskProgressEvent
{
    public ExampleVideoPlayed(int stepId, string videoUrl)
    {
        StepId = stepId;
        VideoUrl = videoUrl;
    }

    public int StepId { get; private set; }

    public string VideoUrl { get; private set;}
}