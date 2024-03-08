using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class Activity : Entity
{
    public int UnitId { get; private set; }
    public int ParentId { get; private set; }
    public int Order {  get; private set; }
    public string? Code { get; private set; }
    public string? Name { get; private set; }
    public string? Guidance { get; private set; }
    public List<Example>? Examples { get; private set; }
    public SubmissionFormat? SubmissionFormat { get; private set; }
    public List<Standard>? Standards { get; private set; }
    public double MaxPoints { get; private set; }

    public void CalculateMaxPoints()
    {
        MaxPoints = Standards?.Sum(s => s.MaxPoints) ?? 0;
    }
}