using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class Step : Entity
{
    public int Order { get; private set; }
    public int ActivityId { get; private set; }
    public string? ActivityName { get; private set; }
    public SubmissionFormat? SubmissionFormat { get; private set; }
    public List<Standard>? Standards { get; private set; }
    public double MaxPoints { get; private set; }

    public void CalculateMaxPoints()
    {
        MaxPoints = Standards?.Sum(s => s.MaxPoints) ?? 0;
    }
}