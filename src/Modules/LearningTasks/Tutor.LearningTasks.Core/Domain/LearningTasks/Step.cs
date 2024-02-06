using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class Step : Entity
{
    public int Order { get; private set; }
    public int ActivityId { get; private set; }
    public string? ActivityName { get; private set; }
    public SubmissionFormat? SubmissionFormat { get; private set; }
    public List<Standard> Standards { get; private set; }
    public double MaxPoints { get; private set; }

    public void Update(Step step)
    {
        Order = step.Order;
        ActivityId = step.ActivityId;
        ActivityName = step.ActivityName;
        SubmissionFormat = step.SubmissionFormat;
        UpdateStandards(step.Standards);
        MaxPoints = Standards.Sum(s => s.MaxPoints);
    }

    private void UpdateStandards(List<Standard> standards)
    {
        foreach (var standard in standards)
        {
            if (standard.Id != 0)
            {
                var existingStandard = Standards.Find(s => s.Id == standard.Id);
                existingStandard?.Update(standard);
            }
            else
            {
                Standards.Add(standard);
            }
        }
        Standards.RemoveAll(s => !standards.Contains(s));
    }

    public void SetMaxPoints()
    {
        MaxPoints = Standards.Sum(s => s.MaxPoints);
    }
}