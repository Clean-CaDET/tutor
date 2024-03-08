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

    public void CalculateMaxPoints()
    {
        MaxPoints = Steps?.Sum(s => s.MaxPoints) ?? 0;
    }

    public void AddStep(Activity newStep)
    {
        newStep.CalculateMaxPoints();
        Steps?.Add(newStep);
        CalculateMaxPoints();
    }

    public Activity? GetStep(string code)
    {
        return Steps?.Find(s => s.Code == code);
    }

    public void UpdateStep(Activity step)
    {
        if (Steps == null) return;
        step.CalculateMaxPoints();
        int index = Steps.FindIndex(s => s.Id == step.Id);
        if (index == -1) return;
        Steps[index] = step;
        CalculateMaxPoints();
    }

    public void RemoveStep(int id)
    {
        Steps?.RemoveAll(s => s.Id == id);
        CalculateMaxPoints();
    }
}