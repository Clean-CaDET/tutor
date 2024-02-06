using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.LearningTasks.Core.Domain.Activities;

public class Activity : AggregateRoot
{
    public string? Code { get; private set; }
    public int CourseId { get; private set; }
    public string? Name { get; private set; }
    public Guidance? Guidance { get; private set; }
    public List<Example>? Examples { get; private set; }
    public List<ActivityStandard>? Standards { get; private set; } 
    public List<Subactivity>? Subactivities { get; private set; }
}