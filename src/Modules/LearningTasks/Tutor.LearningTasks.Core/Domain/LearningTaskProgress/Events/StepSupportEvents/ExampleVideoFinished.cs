namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepSupportEvents;
public class ExampleVideoFinished : StepSupportEvent
{
    public ExampleVideoFinished(int stepId, string videoUrl)
    {
        StepId = stepId;
        VideoUrl = videoUrl;
    }

    public string VideoUrl { get; private set; }
}