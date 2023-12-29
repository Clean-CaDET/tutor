using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain;

public class Step : Entity
{
    public int Order { get; private set; }
    public int ActivityId { get; private set; }
    public string ActivityName { get; private set; }
    public int MaxPoints { get; private set; }
    public List<Standard> Standards { get; private set; }
    public SubmissionFormat SubmissionFormat { get; private set; }

    public Step(int order, int activityId, string activityName, int maxPoints, List<Standard> standards, SubmissionFormat submissionFormat)
    {
        Order = order;
        ActivityId = activityId;
        ActivityName = activityName;
        MaxPoints = maxPoints;
        Standards = standards;
        SubmissionFormat = submissionFormat;
    }
}
