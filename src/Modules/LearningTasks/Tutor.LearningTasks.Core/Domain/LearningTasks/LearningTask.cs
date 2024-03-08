﻿using System.Diagnostics;
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
}