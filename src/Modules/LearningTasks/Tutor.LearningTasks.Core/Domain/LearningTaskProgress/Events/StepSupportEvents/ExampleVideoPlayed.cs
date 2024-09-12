namespace Tutor.LearningTasks.Core.Domain.LearningTaskProgress.Events.StepSupportEvents;
public class ExampleVideoPlayed : StepSupportEvent
{
    public ExampleVideoPlayed(int stepId, string videoUrl)
    {
        StepId = stepId;
        VideoUrl = videoUrl;
    }

    public string VideoUrl { get; private set; }
}