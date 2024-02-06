using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.LearningTasks;

public class LearningTask : AggregateRoot
{
    public int UnitId { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public bool IsTemplate { get; private set; }
    public DomainModel? DomainModel { get; private set; }
    public List<CaseStudy>? CaseStudies { get; private set; }
    public List<Step> Steps { get; private set; }
    public double MaxPoints {  get; private set; }

    public void Update(LearningTask learningTask)
    {
        UnitId = learningTask.UnitId;
        Name = learningTask.Name;
        Description = learningTask.Description;
        IsTemplate = learningTask.IsTemplate;
        DomainModel = learningTask.DomainModel;
        CaseStudies = learningTask.CaseStudies;
        UpdateSteps(learningTask.Steps);
        MaxPoints = Steps.Sum(s => s.MaxPoints);
    }

    private void UpdateSteps(List<Step> steps)
    {
        foreach (var step in steps)
        {
            if (step.Id != 0)
            {
                var existingStep = Steps.Find(s => s.Id == step.Id);
                existingStep?.Update(step);
            }
            else
            {
                Steps.Add(step);
            }
        }
        Steps.RemoveAll(s => !steps.Contains(s));
    }

    public void SetMaxPoints()
    {
        MaxPoints = Steps.Sum(s => s.MaxPoints);
    }
}