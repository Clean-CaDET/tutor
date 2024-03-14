using System.Diagnostics;
using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class LearningTask : AggregateRoot
{
    public int UnitId { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public bool IsTemplate { get; private set; }
    public List<Activity>? Steps { get; private set; }
    public double MaxPoints { get; private set; }

    public void Update(LearningTask learningTask)
    {
        UnitId = learningTask.UnitId;
        Name = learningTask.Name;
        Description = learningTask.Description;
        IsTemplate = learningTask.IsTemplate;
        Steps = learningTask.Steps;
        MaxPoints = Steps?.Sum(s => s.MaxPoints) ?? 0;
    }

    public void UpdateHeader(string name, string description, bool isTemplate)
    {
        Name = name;
        Description = description;
        IsTemplate = isTemplate;
    }

    public void CalculateMaxPoints()
    {
        MaxPoints = Steps?.Sum(s => s.MaxPoints) ?? 0;
    }

    public LearningTask Clone(int newUnitId)
    {
        return new LearningTask
        {
            Name = Name,
            Description = Description,
            UnitId = newUnitId,
            IsTemplate = IsTemplate,
            Steps = Steps?.Select(a => a.Clone()).ToList()
        };
    }

    public void LinkActivityParents(LearningTask oldTask)
    {
        foreach (var oldActivity in oldTask.Steps!)
        {
            if(oldActivity.ParentId == 0) continue;

            var matchingActivity = Steps!.Find(a => a.Code == oldActivity.Code);
            var oldActivityParent = oldTask.Steps.Find(a => a.Id == oldActivity.ParentId);
            var matchingActivityParent = Steps.Find(a => a.Code == oldActivityParent?.Code);
            if (matchingActivity == null || oldActivityParent == null || matchingActivityParent == null)
            {
                throw new InvalidOperationException("Linking activity parents failed.");
            }

            matchingActivity.ParentId = matchingActivityParent.Id;
        }
    }
}