namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepSupportEvents;
public class ExampleVideoPaused : StepSupportEvent
{
    public ExampleVideoPaused(int stepId, string videoUrl)
    {
        StepId = stepId;
        VideoUrl = videoUrl;
    }

    public string VideoUrl { get; private set; }
}