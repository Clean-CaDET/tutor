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
    public List<Step>? Steps { get; private set; }
    public double MaxPoints {  get; private set; }

    public void CalculateMaxPoints()
    {
        MaxPoints = Steps?.Sum(s => s.MaxPoints) ?? 0;
    }
}